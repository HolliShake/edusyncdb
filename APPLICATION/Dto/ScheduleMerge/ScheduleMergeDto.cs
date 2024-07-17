using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScheduleMerge;
public class ScheduleMergeDto
{
    public string MergeCode { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
}
