namespace DOMAIN.Model;

public class Schedule
{
    public int Id { get; set; }
    public String GeneratedReference { get; set; }
    public String GeneratedSection { get; set; }

    public DateTime? DaySchedule { get; set; }
    public DateTime? TimeScheduleIn { get; set; }
    public DateTime? TimeScheduleOut { get; set; }

    public int MinStudent { get; set; }
    public int MaxStudent { get; set; }
    public bool IsPetitionSchedule { get; set; }
    public bool IsExclusive { get; set; }

    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }
    public AcademicProgram AcademicProgram { get; set; }

    // Fk Cycle 
    public int CycleId { get; set; }
    public Cycle Cycle { get; set; }

    // Fk Room
    public int? RoomId { get; set; }
    public Room Room { get; set; }

    // Fk Course
    public int? CourseId { get; set; }
    public Course Course { get; set; }

    // Fk User
    public string CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; }
}