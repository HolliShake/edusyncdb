namespace APPLICATION.Dto.ScheduleAssignment;

public class ScheduleAssignmentMergeCodeDto 
{
    public DateTime DaySchedule { get; set; }
    public DateTime TimeScheduleIn { get; set; }
    public DateTime TimeScheduleOut { get; set; }
    public DateTime? ExpiryDate { get; set; }

    // Fk Room
    public int RoomId { get; set; }
}