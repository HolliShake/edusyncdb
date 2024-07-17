namespace DOMAIN.Model;

public class ScheduleMerge
{
    public int Id { get; set; }

    public string MergeCode { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
}