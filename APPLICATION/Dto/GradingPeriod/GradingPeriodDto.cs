using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradingPeriod;
public class GradingPeriodDto
{
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string GradingPeriodDescription { get; set; }
    [Required]
    public int GradingNumber { get; set; }
    // Fk
    public int CollegeId { get; set; }
}
