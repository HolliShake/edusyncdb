using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AcademicTerm;
public class AcademicTermDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(75)]
    public string AcademicTermDescription { get; set; }
    [Required]
    public int NumberOfGradingPeriod { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(25)]
    public string Label { get; set; }
}
