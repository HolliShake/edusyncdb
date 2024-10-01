namespace DOMAIN.Model;

public class AdmissionEducationalBackground
{
    public int Id { get; set; }
    public string SchoolName { get; set; }
    public AdmissionEducationalBackgroundEduType Type { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    // Fk
    public int ApplicantId { get; set; }

    public AdmissionApplicant Applicant { get; set; }
}