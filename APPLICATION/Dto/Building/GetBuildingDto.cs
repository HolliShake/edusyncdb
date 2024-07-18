using APPLICATION.Dto.Campus;
using APPLICATION.Dto.FileManager;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Building;
public class GetBuildingDto
{
    public int Id { get; set; }
    public string BuildingName { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    // Images
    public List<GetFileManagerTableDto> Images { get; set; }

    // Fk Campus
    public int CampusId { get; set; }
    public GetCampusDto Campus { get; set; }
}
