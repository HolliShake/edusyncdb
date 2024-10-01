using APPLICATION.Dto.AdmissionApplicant;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionApplicantFamilyDetails;
public class GetAdmissionApplicantParentDetailsDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string Relationship { get; set; }
    public string? Occupation { get; set; }

    public decimal? MonthlyIncome { get; set; }

    public decimal? YearlyCompensation { get; set; }

    // Fk AdmissionApplicant
    public int AdmissionApplicantId { get; set; }
    public GetAdmissionApplicantDto Applicant { get; set; }
}
