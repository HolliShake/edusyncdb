using APPLICATION.Dto.Enrollment;
using APPLICATION.Dto.EvaluationPeriod;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EvaluationRating;
public class EvaluationRatingDto
{
    public string OverallComment { get; set; }
    public bool IsPosted { get; set; }
    public DateTime RatingDateTime { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }

    // Fk EvaluationPeriod
    public int EvaluationPeriodId { get; set; }
}
