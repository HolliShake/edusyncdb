using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScholarshipApplication;
public class ScholarshipApplicationDto
{
    public string ApplicationStatus { get; set; }
    public string ApplicationType { get; set; }
    public bool IsApproved { get; set; }
    public DateTime ApplicationDateTime { get; set; }
    public DateTime PostedDateTime { get; set; }

    // Fk ScholarshipCycleLimit
    public int ScholarshipCycleLimitId { get; set; }

    // Fk User
    public string ApplicantUserId { get; set; }
}
