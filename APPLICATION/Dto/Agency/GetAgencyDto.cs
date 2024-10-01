using APPLICATION.Dto.Campus;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Agency;
public class GetAgencyDto
{
    public int Id { get; set; }
    public string AgencyName { get; set; }
    public string ShortName { get; set; }
    public string AgencyAddress { get; set;}

    // Nav
    public virtual ICollection<GetCampusDto> Campuses { get; set; }
}
