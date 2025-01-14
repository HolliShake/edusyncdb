using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.CampusScheduler;
public class CampusSchedulerDto
{

    // Fk (User)
    [Required]
    public string SchedulerUserId { get; set; }

    // Fk (Campus)
    [Required]
    public int CampusId { get; set; }

    // Fk (ScheduleAssignment)
    [Required]
    public int ScheduleAssignementId { get; set; }
}
