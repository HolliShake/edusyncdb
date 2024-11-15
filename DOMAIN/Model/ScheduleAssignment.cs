namespace DOMAIN.Model;

public class ScheduleAssignment
{
    public int Id { get; set; }
    public DateTime DaySchedule { get; set; }
    public DateTime TimeScheduleIn { get; set; }
    public DateTime TimeScheduleOut { get; set; }

    // Fk Room
    public int RoomId { get; set; }
    public Room Room { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
}