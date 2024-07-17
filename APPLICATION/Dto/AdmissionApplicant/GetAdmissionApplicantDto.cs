using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionApplicant;
public class GetAdmissionApplicantDto
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string? Middlename { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public DateTime DateTime { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
}
