using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class AdmissionApplicantFamilyDetails
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Religion { get; set; }

    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string Relationship { get; set; }
    public string? Occupation { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal? MonthlyIncome { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal? YearlyCompensation { get; set; }

    // If Sibling
    public int? YearLevel { get; set; }

    // Fk AdmissionApplicant
    public int AdmissionApplicantId { get; set; }
    public AdmissionApplicant Applicant { get; set; }
}