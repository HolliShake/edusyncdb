using APPLICATION.Dto.Schedule;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScheduleMerge;
public class GetScheduleMergeDto
{
    public int Id { get; set; }

    public string MergeCode { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public GetScheduleDto Schedule { get; set; }
}
