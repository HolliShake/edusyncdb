

using APPLICATION.Dto.EvaluationRatingDetail;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EvaluationRating;

public class EvaluationRatingGroupDto
{
    [Required]
    public int EnrollmentId { get; set; }

    [Required]
    public int EvaluationPeriodId { get; set; }

    [Required]
    public int ScheduleTeacherId { get; set; }

    [Required]
    public string OverAllComment { get; set; }

    [Required]
    public List<EvaluationRatingDetailGroupDto> EvaluationRatingDetails { get; set; }
}