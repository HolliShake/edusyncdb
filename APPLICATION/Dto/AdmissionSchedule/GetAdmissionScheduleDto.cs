using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.Cycle;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionSchedule;
public class GetAdmissionScheduleDto
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsClosedOverride { get; set; }
    public bool IntakeLimit { get; set; }

    // Fk Program
    public int AcademicProgramId { get; set; }
    public GetAcademicProgramDto AcademicProgram { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
    public GetCycleDto Cycle { get; set; }
}
