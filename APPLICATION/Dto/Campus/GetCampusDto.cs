using APPLICATION.Dto.Agency;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Campus;
public class GetCampusDto
{
    public int Id { get; set; }
    public string CampusName { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    // Fk Agency
    public int AgencyId { get; set; }
    public GetAgencyDto Agency { get; set; }
}
