

namespace DOMAIN.Model;

public class AcademicCalendar
{
    public int Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public bool IsOpenOverride { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
    public Cycle Cycle { get; set; }

    // Fk GradingPeriod
    public int? GradingPeriodId { get; set; }
    public GradingPeriod? GradingPeriod { get; set; }
}