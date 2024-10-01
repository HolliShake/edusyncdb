using System.ComponentModel.DataAnnotations;

namespace DOMAIN.Model;

public class AdmissionApplicant
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public bool? IsSoloParent { get; set; }
    public bool? IsChildOfSoloParent { get; set; }
    public bool IsOnsite { get; set; }
    public AdmissionApplicantType ApplicationType { get; set; }
    public int AcademicProgramChoiceId1 { get; set; }
    public int AcademicProgramChoiceId2 { get; set; }
    public int? AcademicProgramChoiceId3 { get; set; }
}