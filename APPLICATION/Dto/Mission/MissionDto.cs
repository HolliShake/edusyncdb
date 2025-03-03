
namespace APPLICATION.Dto.Mission;

public class MissionDto
{
    public string MissionDescText { get; set; }

    public bool IsDefault { get; set; }

    // Navigation Property
    public int VisionId { get; set; }
}