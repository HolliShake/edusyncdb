using APPLICATION.Dto.AdmissionApplicant;
using APPLICATION.Dto.AdmissionSchedule;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionApplication;
public class GetAdmissionApplicationDto
{
    public int Id { get; set; }
    public string ApplicationReferenceNumber { get; set; } // Generated code
    public string? Notes { get; set; }
    public string OverAllStatus { get; set; }
    public DateTime SubmissionDate { get; set; } = DateTime.Now;
    // Fk AdmissionSchedule
    public int AdmissionScheduleId { get; set; }
    public GetAdmissionScheduleDto AdmissionSchedule { get; set; }
    // Fk AddmisionApplicant
    public int AdmissionApplicantId { get; set; }
    public GetAdmissionApplicantDto AdmissionApplicant { get; set; }
}
