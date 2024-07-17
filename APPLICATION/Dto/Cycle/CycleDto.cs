using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Cycle;
public class CycleDto
{
    [Required]
    [MinLength(4)]
    [MaxLength(255)]
    public string CycleDescription { get; set; }
    [Required]
    public int CylceNumber { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string SchoolYear { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    // Fk Campus
    [Required]
    public int CampusId { get; set; }
}
