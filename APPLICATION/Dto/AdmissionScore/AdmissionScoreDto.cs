using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.AdmissionScore;
public class AdmissionScoreDto
{
    [Column(TypeName = "decimal(18,4)")]
    [Required]
    public decimal ActualScore { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(255)]
    public string EvaluationRemarks { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(25)]
    public string PassingStatus { get; set; }
    [Required]
    public DateTime EvaluationPostDateTime { get; set; }

    // Fk User
    public string EvaluatorId { get; set; }

    // Fk AdmissioNEvaluationSchedule
    [Required]
    public int AdmissionEvaluationScheduleId { get; set; }

    // Fk AdmissionProgramRequirement
    [Required]
    public int AdmissionProgramRequirementId { get; set; }

    // Fk AdmissionApplicant
    [Required]
    public int AdmissionApplicantId { get; set; }
}
