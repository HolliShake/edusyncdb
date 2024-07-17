using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class ScholarshipApplication
{
    public int Id { get; set; }
    public string ApplicationStatus { get; set; }
    public string ApplicationType { get; set; }
    public bool IsApproved { get; set; }
    public DateTime ApplicationDateTime { get; set; }
    public DateTime PostedDateTime { get; set; }

    // Fk ScholarshipCycleLimit
    public int ScholarshipCycleLimitId { get; set; }
    public ScholarshipCycleLimit ScholarshipCycleLimit { get; set; }

    // Fk User
    [ForeignKey("ApplicantUser")]
    public string ApplicantUserId { get; set; }
    public User ApplicantUser { get; set; }
}