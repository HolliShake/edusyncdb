using APPLICATION.Dto.Campus;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Agency;
public class GetAgencyDto
{
    public int Id { get; set; }
    public string AgencyName { get; set; }
    public string AgencyAddress { get; set;}
    public string AgencyComputedShortName
    {
        get
        {
            var arr = this.AgencyName.Split(" ");
            var str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsUpper(arr[i][0]))
                {
                    str += arr[i][0];
                }
            }
            return str;
        }
    }

    // Nav
    public virtual ICollection<GetCampusDto> Campuses { get; set; }
}
