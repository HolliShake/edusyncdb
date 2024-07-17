using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.College;

public class CollegeDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string CollegeName { get; set; }
    // Fk Campus
    [Required]
    public int CampusId { get; set; }
}
