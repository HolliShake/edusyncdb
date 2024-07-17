using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Building;
public class BuildingDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string BuildingName { get; set; }
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }

    // Fk Campus
    [Required]
    public int CampusId { get; set; }
}
