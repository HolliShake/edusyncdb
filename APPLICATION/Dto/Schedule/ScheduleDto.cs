using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Schedule;
public class ScheduleDto
{
    public int Id { get; set; }
    public String GeneratedReference { get; set; }
    public String GeneratedSection { get; set; }

    public DateTime DaySchedule { get; set; }
    public DateTime TimeScheduleIn { get; set; }
    public DateTime TimeScheduleOut { get; set; }

    public int MinStudent { get; set; }
    public int MaxStudent { get; set; }
    public bool IsPetitionSchedule { get; set; }

    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }

    // Fk Cycle 
    public int CycleId { get; set; }

    // Fk Room
    public int RoomId { get; set; }

    // Fk Course
    public int CourseId { get; set; }
}
