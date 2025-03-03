
namespace DOMAIN.Model;

public class Agency
{
    public int Id { get; set; }
    public string AgencyName { get; set; }
    public string ShortName { get; set; }
    public string AgencyAddress { get; set;}

    public string Code { get; set; }

    // Nav
    public virtual ICollection<Campus> Campuses { get; set; }
}