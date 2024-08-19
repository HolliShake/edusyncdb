using APPLICATION.Dto.Schedule;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBook;
public class GradeBookDto
{
    public string GradeBookDescription { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
}
