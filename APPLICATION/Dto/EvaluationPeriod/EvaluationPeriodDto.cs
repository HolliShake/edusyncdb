using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EvaluationPeriod;
public class EvaluationPeriodDto
{
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public bool IsOpenOverride { get; set; }
    public bool IsEnabled { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }

    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }

    // Fk Instrument
    public int InstrumentId { get; set; }

    // Fk EnrollmentRole
    public int EnrollmentRoleId { get; set; }
    
    // Fk User (CreatedBy)
    public string CreatedByUserId { get; set; }
}
