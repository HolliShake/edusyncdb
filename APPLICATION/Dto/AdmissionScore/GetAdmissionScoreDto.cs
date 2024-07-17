using APPLICATION.Dto.AdmissionApplicant;
using APPLICATION.Dto.AdmissionEvaluationSchedule;
using APPLICATION.Dto.AdmissionProgramRequirement;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.AdmissionScore;
public class GetAdmissionScoreDto
{
    public int Id { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal ActualScore { get; set; }
    public string EvaluationRemarks { get; set; }
    public string PassingStatus { get; set; }
    public DateTime EvaluationPostDateTime { get; set; }

    // Fk User
    public string EvaluatorId { get; set; }
    public GetUserOnlyDto Evaluator { get; set; }

    // Fk AdmissioNEvaluationSchedule
    public int AdmissionEvaluationScheduleId { get; set; }
    public GetAdmissionEvaluationScheduleDto AdmissionEvaluationSchedule { get; set; }

    // Fk AdmissionProgramRequirement
    public int AdmissionProgramRequirementId { get; set; }
    public GetAdmissionProgramRequirementDto AdmissionProgramRequirement { get; set; }

    // Fk AdmissionApplicant
    public int AdmissionApplicantId { get; set; }
    public GetAdmissionApplicantDto AdmissionApplicant { get; set; }
}
