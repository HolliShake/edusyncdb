
namespace DOMAIN.Model;

public class Vision
{
    public int Id { get; set; }

    public string VisionDescription { get; set; } = string.Empty;

    public bool IsDefault { get; set; }

    public int AgencyId { get; set; }
    public Agency Agency { get; set; }
}