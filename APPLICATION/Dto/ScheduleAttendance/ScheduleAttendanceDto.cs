using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScheduleAttendance;
public class ScheduleAttendanceDto
{
    public DateTime CheckInDateTime { get; set; }
    public DateTime CheckOutDateTime { get; set; }

    //
    public float InLatitude { get; set; }
    public float InLongitude { get; set; }
    public float OutLatitude { get; set; }
    public float OutLongitude { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }

    // Fk User
    public string AnyUserId { get; set; }
}
