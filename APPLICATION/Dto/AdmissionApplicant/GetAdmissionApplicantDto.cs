using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionApplicant;
public class GetAdmissionApplicantDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime DateTime { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
}
