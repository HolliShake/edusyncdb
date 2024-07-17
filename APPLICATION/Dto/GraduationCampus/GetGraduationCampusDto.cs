using APPLICATION.Dto.Campus;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GraduationCampus;
public class GetGraduationCampusDto
{
    public int Id { get; set; }
    public DateTime GraduationDateTime { get; set; }
    public string GraduationTheme { get; set; }
    public string Venue { get; set; }
    public float VenueLatitude { get; set; }
    public float VenueLongitude { get; set; }
    public string BORResolution { get; set; }
    public string GuestOfHonor { get; set; }
    public DateTime ApplicationStartDate { get; set; }
    public DateTime ApplicationEndDate { get; set; }

    // Fk Campus
    public int CampusId { get; set; }
    public GetCampusDto Campus { get; set; }
}
