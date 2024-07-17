using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionSchedule;
public class AdmissionScheduleDto
{
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public bool IsClosedOverride { get; set; }
    [Required]
    public bool IntakeLimit { get; set; }

    // Fk Program
    [Required]
    public int AcademicProgramId { get; set; }

    // Fk Cycle
    [Required]
    public int CycleId { get; set; }
}
