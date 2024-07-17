using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class ScholarshipEvaluation
{
    public int Id { get; set; }

    public string EvaluationDescription { get; set; }
    public string EvaluationStatus { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal EvalScore { get; set; }

    // Fk User
    [ForeignKey("EvaluatorUser")]
    public string EvaluatorUserId { get; set; }
    public User EvaluatorUser { get; set; }

    // Fk ScholarshipApplication
    public int ScholarshipApplicationId { get; set; }
    public ScholarshipApplication ScholarshipApplication { get; set; }

    // Fk ScholarshipRequirement
    public int ScholarshipRequirementId { get; set; }
    public ScholarshipRequirement ScholarshipRequirement { get; set; }
}