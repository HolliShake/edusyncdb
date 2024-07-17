using APPLICATION.Dto.Schedule;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBook;
public class GradeBookDto
{
    public int Id { get; set; }
    public string GradeBookDescription { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public GetScheduleDto Schedule { get; set; }
}
