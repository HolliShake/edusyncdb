using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBook;
public class GetGradeBookDto
{
    public string GradeBookDescription { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
}
