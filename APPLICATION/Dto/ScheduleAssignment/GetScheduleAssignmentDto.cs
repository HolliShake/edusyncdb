using APPLICATION.Dto.Room;
using APPLICATION.Dto.Schedule;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScheduleAssignment;
public class GetScheduleAssignmentDto
{
    public int Id { get; set; }
    public DateTime DaySchedule { get; set; }
    public DateTime TimeScheduleIn { get; set; }
    public DateTime TimeScheduleOut { get; set; }

    // Fk Room
    public int RoomId { get; set; }
    public GetRoomDto Room { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public GetScheduleDto Schedule { get; set; }
}
