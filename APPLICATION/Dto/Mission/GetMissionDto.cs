using APPLICATION.Dto.Vision;
using DOMAIN.Model;

namespace APPLICATION.Dto.Mission;

public class GetMissionDto
{
    public int Id { get; set; }

    public string MissionDescText { get; set; }

    public bool IsDefault { get; set; }

    // Navigation Property
    public int VisionId { get; set; }
    public GetVisionDto Visiom { get; set; }
}