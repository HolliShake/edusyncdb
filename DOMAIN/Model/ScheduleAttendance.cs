using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class ScheduleAttendance
{
    public int Id { get; set; }
    public DateTime CheckInDateTime { get; set; }
    public DateTime CheckOutDateTime { get; set; }

    //
    public float InLatitude { get; set; }
    public float InLongitude { get; set; }
    public float OutLatitude { get; set; }
    public float OutLongitude { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    // Fk User
    [ForeignKey("AnyUser")]
    public string AnyUserId { get; set; }
    public User AnyUser { get; set; }
}