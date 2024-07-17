using APPLICATION.Dto.Enrollment;
using APPLICATION.Dto.EvaluationPeriod;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EvaluationRating;
public class GetEvaluationRatingDto
{
    public int Id { get; set; }
    public string OverallComment { get; set; }
    public bool IsPosted { get; set; }
    public DateTime RatingDateTime { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
    public GetEnrollmentDto Enrollment { get; set; }

    // Fk EvaluationPeriod
    public int EvaluationPeriodId { get; set; }
    public GetEvaluationPeriodDto EvaluationPeriod { get; set; }
}
