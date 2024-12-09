using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using DOMAIN.Model;

namespace INFRASTRUCTURE;

public class Utility
{
    private static double EARTH_RADIUS = 6371.0; // Kilometers

    /// <summary>
    /// 
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string AddSuffix(int number)
    {
        if (number <= 0) return number.ToString();

        // Get the last digit of the number
        int lastDigit = number % 10;

        // Determine the suffix
        string suffix = "th"; // Default suffix

        if (number % 100 is < 11 or > 13) // Handle the exceptions for 11th, 12th, and 13th
        {
            suffix = lastDigit switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
        }

        return $"{number}{suffix}";
    }

    private static double ToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }

    /// <summary>
    /// Calculate the Haversine distance between two points (lat1, lon1) and (lat2, lon2).
    /// </summary>
    /// <param name="lat1">Latitude of the first point.</param>
    /// <param name="lon1">Longitude of the first point.</param>
    /// <param name="lat2">Latitude of the second point.</param>
    /// <param name="lon2">Longitude of the second point.</param>
    /// <returns>The distance between the two points in kilometers.</returns>
    public static double CalculateHaversineDistance(double lat1, double lon1, double lat2, double lon2)
    {
        double dLat = ToRadians(lat2 - lat1);
        double dLon = ToRadians(lon2 - lon1);

        double lat1Rad = ToRadians(lat1);
        double lat2Rad = ToRadians(lat2);

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        // Calculate the distance
        return EARTH_RADIUS * c;
    }

    /// <summary>
    /// Check if a point (lat2, lon2) is within a certain range (in kilometers) from another point (lat1, lon1).
    /// </summary>
    /// <param name="lat1">Latitude of the first point.</param>
    /// <param name="lon1">Longitude of the first point.</param>
    /// <param name="lat2">Latitude of the second point.</param>
    /// <param name="lon2">Longitude of the second point.</param>
    /// <param name="rangeInKm">The range in kilometers.</param>
    /// <returns>True if (lat2, lon2) is within range of (lat1, lon1), otherwise false.</returns>
    public static bool IsWithinRange(double lat1, double lon1, double lat2, double lon2, double rangeInKm)
    {
        double distance = CalculateHaversineDistance(lat1, lon1, lat2, lon2);
        return distance <= rangeInKm;
    }

    public static (double? Latitude, double? Longitude) GetGeoTag(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return (null, null);

        try
        {
            // Read the stream from the uploaded IFormFile
            using (var stream = file.OpenReadStream())
            {
                // Read metadata from the stream
                var directories = ImageMetadataReader.ReadMetadata(stream);

                // Find the EXIF SubIFD directory
                var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
                var gpsDirectory = directories.OfType<GpsDirectory>().FirstOrDefault();

                if (gpsDirectory != null)
                {
                    // Get GPS latitude and longitude values
                    var latitude = GetGpsCoordinate(gpsDirectory.GetDescription(GpsDirectory.TagLatitude), gpsDirectory.GetDescription(GpsDirectory.TagLatitudeRef));
                    var longitude = GetGpsCoordinate(gpsDirectory.GetDescription(GpsDirectory.TagLongitude), gpsDirectory.GetDescription(GpsDirectory.TagLongitudeRef));

                    return (latitude, longitude);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., logging)
            Console.WriteLine($"Error reading metadata: {ex.Message}");
        }

        return (null, null);
    }

    private static double? GetGpsCoordinate(string coordinateString, string coordinateRef)
    {
        if (string.IsNullOrEmpty(coordinateString) || string.IsNullOrEmpty(coordinateRef))
            return null;

        // Example format: "12° 34' 56.78"" N"
        var parts = coordinateString.Split(' ');

        if (parts.Length < 3)
            return null;

        if (double.TryParse(parts[0].TrimEnd('°'), NumberStyles.Float, CultureInfo.InvariantCulture, out var degrees) &&
            double.TryParse(parts[1].TrimEnd('\''), NumberStyles.Float, CultureInfo.InvariantCulture, out var minutes) &&
            double.TryParse(parts[2].TrimEnd('"'), NumberStyles.Float, CultureInfo.InvariantCulture, out var seconds))
        {
            // Convert to decimal degrees
            var decimalDegrees = degrees + (minutes / 60) + (seconds / 3600);

            // Check the hemisphere (N/S or E/W)
            if (coordinateRef == "S" || coordinateRef == "W")
                decimalDegrees *= -1;

            return decimalDegrees;
        }

        return null;
    }

    public static List<SimplifiedGradingPeriod> CalculatePerGradingPeriod(List<GradeBookScore> scores)
    {
        var gradingPeriods = scores.GroupBy(g => g.GradeBookItemDetail.GradeBookItem.GradingPeriod)
        .Select(g =>
        {
            var gradingPeriodTitle = g.Key.GradingPeriodDescription;
            var totalWeightedScore = g.Sum(g =>
                (((g.Score / g.GradeBookItemDetail.MaxScore) * 100)
                * g.GradeBookItemDetail.Weight)
                * g.GradeBookItemDetail.GradeBookItem.Weight); 

            return new SimplifiedGradingPeriod
            {
                GradingPeriodId = g.Key.Id,
                GradingPeriod = gradingPeriodTitle,
                Grade = totalWeightedScore
            };
        }).ToList();
        return gradingPeriods;
    }

    public static decimal CalculateFinalGrade(List<SimplifiedGradingPeriod> simplifiedGradingPeriods)
    {
        var gradingPeriods = simplifiedGradingPeriods;
        var finalGrade = (gradingPeriods.Count > 0)
                        ? (gradingPeriods.Sum(x => x.Grade) / gradingPeriods.Count)
                        : 0;
        return finalGrade;
    }

    public static decimal CalculateFinalGrade(List<GradeBookScore> scores)
    {
        var gradingPeriods = CalculatePerGradingPeriod(scores);
        var finalGrade = (gradingPeriods.Count > 0)
                        ? (gradingPeriods.Sum(x => x.Grade) / gradingPeriods.Count)
                        : 0;
        return finalGrade;
    }
}

public class SimplifiedGradingPeriod
{
    public int GradingPeriodId { get; set; }
    public string GradingPeriod { get; set; }
    public decimal Grade { get; set; }
}