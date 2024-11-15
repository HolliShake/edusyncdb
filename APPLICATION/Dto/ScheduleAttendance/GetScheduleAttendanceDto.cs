using APPLICATION.Dto.Schedule;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScheduleAttendance;
public class GetScheduleAttendanceDto
{
    public int Id { get; set; }
    public DateTime AttendanceDateTime { get; set; }
    //
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public bool IsTimeIn { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public GetScheduleDto Schedule { get; set; }

    // Fk User
    public string AnyUserId { get; set; }
    public GetUserOnlyDto AnyUser { get; set; }
}
