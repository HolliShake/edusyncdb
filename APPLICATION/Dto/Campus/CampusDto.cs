using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Campus;
public class CampusDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(75)]
    public string CampusName { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string CampusShortName { get; set; }
    [Required]
    [MinLength(10)]
    [MaxLength(255)]
    public string Address { get; set; }
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }
    // Fk Agency
    [Required]
    public int AgencyId { get; set; }
}
