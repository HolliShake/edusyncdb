namespace APPLICATION.Dto.AdmissionApplicantFamilyDetails;

public class AdmissionFatherDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string Relationship 
    { 
        get 
        { 
            return "Father";
        }
    }
    public string Religion { get; set; }
    public string? Occupation { get; set; }
    public decimal? MonthlyIncome { get; set; }
    public decimal? YearlyCompensation { get; set; }
}