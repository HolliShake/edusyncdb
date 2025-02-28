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

    public string Title { get; set; }
    public string Description { get; set; }

    // Fk Cycle
    [Required]
    public int CycleId { get; set; }

    // Fk GradingPeriod
    public int? GradingPeriodId { get; set; }
}
