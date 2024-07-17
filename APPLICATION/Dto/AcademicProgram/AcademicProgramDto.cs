using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AcademicProgram;
public class AcademicProgramDto
{
    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    public string ProgramName { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(25)]
    public string ShortName { get; set; }
    [Required]
    public DateTime YearFirstImplemented { get; set; }

    // Fk College
    [Required]
    public int CollegeId { get; set; }
}
