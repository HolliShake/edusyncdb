using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class Curriculum
{
    public int Id { get; set; }
    public string CurriculumName { get; set; }
    public string CurriculumCode { get; set; }
    public string Major { get; set; }
    public string Minor { get; set; }
    public string AuthorityLegal { get; set; }
    public int TotalAcademicTerm { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal MinUnitsToBeHonored { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int StudentMaxUnits { get; set; }
    public bool IsActive { get; set; }
    public bool IsDefault { get; set; }

    // Fk AcademicTerm
    public int AcademicTermId { get; set; }
    public AcademicTerm AcademicTerm { get; set; }

    // Fk ProgramType
    public int ProgramTypeId { get; set; }
    public ProgramType ProgramType { get; set; }

    // Fk Program
    public int AcademicProgramId { get; set; }
    public AcademicProgram AcademicProgram { get; set; }

    // FK GradeInput
    [ForeignKey("MinGradeToBeCulled")]
    public int MinGradeToBeCulledId { get; set; }
    public GradeInput MinGradeToBeCulled { get; set; }
}