using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.Curriculum;
public class CurriculumDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string CurriculumName { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(25)]
    public string CurriculumCode { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string Major { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string Minor { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string AuthorityLegal { get; set; }
    [Required]
    public int TotalAcademicTerm { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    [Required]
    public decimal MinUnitsToBeHonored { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public int StudentMaxUnits { get; set; }
    [Required]
    public bool IsActive { get; set; }
    [Required]
    public bool IsDefault { get; set; }

    // Fk AcademicTerm
    [Required]
    public int AcademicTermId { get; set; }

    // Fk ProgramType
    [Required]
    public int ProgramTypeId { get; set; }

    // Fk Program
    [Required]
    public int AcademicProgramId { get; set; }

    // FK GradeInput
    public int MinGradeToBeCulledId { get; set; }
}
