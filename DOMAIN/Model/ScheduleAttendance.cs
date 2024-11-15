using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class ScheduleAttendance
{
    public int Id { get; set; }
    public DateTime AttendanceDateTime { get; set; }

    //
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public bool IsTimeIn { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    // Fk User
    [ForeignKey("AnyUser")]
    public string AnyUserId { get; set; }
    public User AnyUser { get; set; }
}