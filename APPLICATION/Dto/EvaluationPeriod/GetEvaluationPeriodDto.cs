using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.Cycle;
using APPLICATION.Dto.EnrollmentRole;
using APPLICATION.Dto.Instrument;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EvaluationPeriod;
public class GetEvaluationPeriodDto
{
    public int Id { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public bool IsOpenOverride { get; set; }
    public bool IsEnabled { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
    public GetCycleDto Cycle { get; set; }

    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }
    public GetAcademicProgramDto AcademicProgram { get; set; }

    // Fk Instrument
    public int InstrumentId { get; set; }
    public GetInstrumentDto Instrument { get; set; }

    // Fk EnrollmentRole
    public int EnrollmentRoleId { get; set; }
    public GetEnrollmentRoleDto EnrollmentRole { get; set; }
    
    // Fk User (CreatedBy)
    public string CreatedByUserId { get; set; }
    public GetUserOnlyDto CreatedByUser { get; set; }
}
