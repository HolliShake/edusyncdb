namespace APPLICATION.Dto.Vision;

public class VisionDto
{
    public string VisionDescription { get; set; } = string.Empty;

    public bool IsDefault { get; set; }

    public int AgencyId { get; set; }
}