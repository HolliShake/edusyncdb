using APPLICATION.Dto.Campus;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.College;
public class GetCollegeDto
{
    public int Id { get; set; }
    public string CollegeName { get; set; }
    public string CollegeComputedShortName
    {
        get
        {
            var arr = this.CollegeName.Split(" ");
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

    // Fk Campus
    public int CampusId { get; set; }
    public GetCampusDto Campus { get; set; }
}
