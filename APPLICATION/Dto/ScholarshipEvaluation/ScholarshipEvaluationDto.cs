using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScholarshipEvaluation;
public class ScholarshipEvaluationDto
{
    public string EvaluationDescription { get; set; }
    public string EvaluationStatus { get; set; }
    public decimal EvalScore { get; set; }

    // Fk User
    public string EvaluatorUserId { get; set; }

    // Fk ScholarshipApplication
    public int ScholarshipApplicationId { get; set; }

    // Fk ScholarshipRequirement
    public int ScholarshipRequirementId { get; set; }
}
