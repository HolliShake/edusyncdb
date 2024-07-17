using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class AdmissionScore
{
    public int Id { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal ActualScore { get; set; }
    public string EvaluationRemarks { get; set; }
    public string PassingStatus { get; set; }
    public DateTime EvaluationPostDateTime { get; set; }
    // Fk User
    [ForeignKey("Evaluator")]
    public string EvaluatorId { get; set; }
    public User Evaluator { get; set; }

    // Fk AdmissioNEvaluationSchedule
    public int AdmissionEvaluationScheduleId { get; set; }
    public AdmissionEvaluationSchedule AdmissionEvaluationSchedule { get; set; }

    // Fk AdmissionProgramRequirement
    public int AdmissionProgramRequirementId { get; set; }
    public AdmissionProgramRequirement AdmissionProgramRequirement { get; set; }

    // Fk AdmissionApplicant
    public int AdmissionApplicantId { get; set; }
    public AdmissionApplicant AdmissionApplicant { get; set; }
}