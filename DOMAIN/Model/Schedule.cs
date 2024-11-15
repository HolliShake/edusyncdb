namespace DOMAIN.Model;

public class Schedule
{
    public int Id { get; set; }
    public String GeneratedReference { get; set; }
    public String GeneratedSection { get; set; }
    public int MinStudent { get; set; }
    public int MaxStudent { get; set; }
    public bool IsPetitionSchedule { get; set; }
    public bool IsExclusive { get; set; }

    // Fk Cycle 
    public int CycleId { get; set; }
    public Cycle Cycle { get; set; }

    // Fk Curriculum Detail
    public int CurriculumDetailId { get; set; }
    public CurriculumDetail CurriculumDetail { get; set; }

    // Fk User
    public string CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; }

    // Navigation property GradeBook
    public ICollection<GradeBook> GradeBooks { get; set; }

    // Navigation property TeacherSchedule
    public ICollection<ScheduleTeacher> Teachers { get; set; }

    // Navigation property ScheduleAssignment
    public ICollection<ScheduleAssignment> ScheduleAssignments { get; set; }
}