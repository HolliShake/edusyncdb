using APPLICATION.Dto.Schedule;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScheduleAttendance;
public class GetScheduleAttendanceDto
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
    public GetScheduleDto Schedule { get; set; }

    // Fk User
    public string AnyUserId { get; set; }
    public GetUserOnlyDto AnyUser { get; set; }
}
