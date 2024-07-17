using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AcademicCalendar;
public class AcademicCalendarDto
{
    [Required]
    public DateTime StartDateTime { get; set; }
    [Required]
    public DateTime EndDateTime { get; set; }
    [Required]
    public bool IsOpenOverride { get; set; }

    // Fk Cycle
    [Required]
    public int CycleId { get; set; }

    // Fk GradingPeriod
    [Required]
    public int GradingPeriodId { get; set; }
}
