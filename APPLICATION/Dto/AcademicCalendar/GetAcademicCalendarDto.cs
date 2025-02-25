using APPLICATION.Dto.Cycle;
using APPLICATION.Dto.GradingPeriod;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AcademicCalendar;
public class GetAcademicCalendarDto
{
    public int Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public bool IsOpenOverride { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
    public GetCycleDto Cycle { get; set; }

    // Fk GradingPeriod
    public int? GradingPeriodId { get; set; }
    public GetGradingPeriodDto? GradingPeriod { get; set; }
}
