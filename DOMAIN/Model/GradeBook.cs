namespace DOMAIN.Model;

public class GradeBook
{
    public int Id { get; set; }
    public string GradeBookDescription { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    // Nav
    public ICollection<GradeBookItem> GradeBookItems { get; set; }
}