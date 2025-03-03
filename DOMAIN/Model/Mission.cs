

namespace DOMAIN.Model;

public class Mission
{
    public int Id { get; set; }

    public string MissionDescText { get; set; } = string.Empty;

    public bool IsDefault { get; set; }

    // Navigation Property
    public int VisionId { get; set; }
    public Vision Vision { get; set; }
}