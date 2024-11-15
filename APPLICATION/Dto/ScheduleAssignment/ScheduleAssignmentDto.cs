namespace APPLICATION.Dto.ScheduleAssignment;
public class ScheduleAssignmentDto
{
    public DateTime DaySchedule { get; set; }
    public DateTime TimeScheduleIn { get; set; }
    public DateTime TimeScheduleOut { get; set; }

    // Fk Room
    public int RoomId { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
}
