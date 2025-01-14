namespace DOMAIN.Model;

public class CampusScheduler 
{
    public int Id { get; set; }

    // Fk (User)
    public string SchedulerUserId { get; set; }
    public User SchedulerUser { get; set; }

    // Fk (Campus)
    public int CampusId { get; set; }
    public Campus Campus { get; set; }

    // Fk (ScheduleAssignment)
    public int ScheduleAssignementId { get; set; }
    public ScheduleAssignment ScheduleAssignment { get; set; }
}