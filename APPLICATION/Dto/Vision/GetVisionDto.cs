using APPLICATION.Dto.Agency;

namespace APPLICATION.Dto.Vision;

public class GetVisionDto
{
    public int Id { get; set; }

    public string VisionDescription { get; set; }

    public bool IsDefault { get; set; }

    public int AgencyId { get; set; }
    public GetAgencyDto Agency { get; set; }
}