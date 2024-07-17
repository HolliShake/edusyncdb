using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EvaluationRatingDetail;
public class EvaluationRatingDetailDto
{

    public int LikertScaleResponse { get; set; }
    public string QuestionTextResponse { get; set; }

    // Fk EvaluationRating
    public int EvaulationRatingId { get; set; }

    // Fk LikertQuestion
    public int LikertQuestionId { get; set; }
}
