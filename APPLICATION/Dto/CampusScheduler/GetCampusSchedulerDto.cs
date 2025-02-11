using APPLICATION.Dto.ScheduleAssignment;
using APPLICATION.Dto.User;
using APPLICATION.Dto.Campus;

namespace APPLICATION.Dto.CampusScheduler;
public class GetCampusSchedulerDto
{
    public int Id { get; set; }

    // Fk (User)
    public string SchedulerUserId { get; set; }
    public GetUserOnlyDto SchedulerUser { get; set; }

    // Fk (Campus)
    public int CampusId { get; set; }
    public GetCampusDto Campus { get; set; }
}
