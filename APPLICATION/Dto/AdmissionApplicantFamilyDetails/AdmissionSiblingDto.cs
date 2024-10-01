namespace APPLICATION.Dto.AdmissionApplicantFamilyDetails;

public class AdmissionSiblingDto
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
            return "Sibling";
        }
    }
    public string Religion { get; set; }
}