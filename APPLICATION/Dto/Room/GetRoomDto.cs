using APPLICATION.Dto.Building;
using APPLICATION.Dto.ScheduleAssignment;

namespace APPLICATION.Dto.Room;
public class GetRoomDto
{
    public int Id { get; set; }
    public string RoomName { get; set; }
    public int Capacity { get; set; }
    public bool IsLab { get; set; }
    public bool IsEspecializedLab { get; set; }

    // Fk Building
    public int BuildingId { get; set; }
    public GetBuildingDto Building { get; set; }

    // Nav ScheduleAssignment
    public ICollection<GetScheduleAssignmentDto> ScheduleAssignments { get; set; }
}
