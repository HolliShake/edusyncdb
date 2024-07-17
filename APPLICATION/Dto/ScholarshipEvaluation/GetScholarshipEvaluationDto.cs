using APPLICATION.Dto.ScholarshipApplication;
using APPLICATION.Dto.ScholarshipRequirement;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScholarshipEvaluation;
public class GetScholarshipEvaluationDto
{
    public int Id { get; set; }

    public string EvaluationDescription { get; set; }
    public string EvaluationStatus { get; set; }
    public decimal EvalScore { get; set; }

    // Fk User
    public string EvaluatorUserId { get; set; }
    public GetUserOnlyDto EvaluatorUser { get; set; }

    // Fk ScholarshipApplication
    public int ScholarshipApplicationId { get; set; }
    public GetScholarshipApplicationDto ScholarshipApplication { get; set; }

    // Fk ScholarshipRequirement
    public int ScholarshipRequirementId { get; set; }
    public GetScholarshipRequirementDto ScholarshipRequirement { get; set; }
}
