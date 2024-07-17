
namespace DOMAIN.Model;

public class AdmissionSchedule
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsClosedOverride { get; set; }
    public bool IntakeLimit { get; set; }

    // Fk Program
    public int AcademicProgramId { get; set; }
    public AcademicProgram AcademicProgram { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
    public Cycle Cycle { get; set; }
}