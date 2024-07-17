using System.Diagnostics.Metrics;

namespace DOMAIN.Model;

public class EvaluationPeriod
{
    public int Id { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public bool IsOpenOverride { get; set; }
    public bool IsEnabled { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
    public Cycle Cycle { get; set; }

    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }
    public AcademicProgram AcademicProgram { get; set; }

    // Fk Instrument
    public int InstrumentId { get; set; }
    public Instrument Instrument { get; set; }

    // Fk EnrollmentRole
    public int EnrollmentRoleId { get; set; }
    public EnrollmentRole EnrollmentRole { get; set; }
    
    // Fk User (CreatedBy)
    public string CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; }
}