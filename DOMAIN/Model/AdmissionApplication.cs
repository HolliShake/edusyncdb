namespace DOMAIN.Model;

public class AdmissionApplication
{
    public int Id { get; set; }
    public string ApplicationReferenceNumber { get; set; } // Generated code
    public string? Notes { get; set; }
    public string OverAllStatus { get; set; }
    public DateTime SubmissionDate { get; set; } = DateTime.Now;
    // Fk AdmissionSchedule
    public int AdmissionScheduleId { get; set; }
    public AdmissionSchedule AdmissionSchedule { get; set; }
    // Fk AddmisionApplicant
    public int AdmissionApplicantId { get; set; }
    public AdmissionApplicant AdmissionApplicant { get; set; }
}