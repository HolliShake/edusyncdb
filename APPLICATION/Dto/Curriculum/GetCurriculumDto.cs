using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.AcademicTerm;
using APPLICATION.Dto.GradeInput;
using APPLICATION.Dto.ProgramType;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.Curriculum;
public class GetCurriculumDto
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
    public GetAcademicTermDto AcademicTerm { get; set; }

    // Fk ProgramType
    public int ProgramTypeId { get; set; }
    public GetProgramTypeDto ProgramType { get; set; }

    // Fk Program
    public int AcademicProgramId { get; set; }
    public GetAcademicProgramDto AcademicProgram { get; set; }

    // FK GradeInput
    public int MinGradeToBeCulledId { get; set; }
    public GetGradeInputDto MinGradeToBeCulled { get; set; }
}
