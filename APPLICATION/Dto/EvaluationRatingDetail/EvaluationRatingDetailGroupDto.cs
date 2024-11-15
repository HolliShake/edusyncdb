
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EvaluationRatingDetail;

public class EvaluationRatingDetailGroupDto
{
    [Required]
    public int LikertQuestionId { get; set; }

    [Required]
    public int LikertScaleResponse { get; set; }

    [Required]
    public string QuestionTextResponse { get; set; }
}