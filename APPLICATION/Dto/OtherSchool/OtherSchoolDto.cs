using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.OtherSchool;
public class OtherSchoolDto
{
    public int Id { get; set; }
    public string SchoolName { get; set; }
    public string SchoolCampus { get; set; }
    public string Address { get; set; }
    public string Mobile { get; set; }
}
