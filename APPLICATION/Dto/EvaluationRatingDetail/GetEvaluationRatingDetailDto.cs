using APPLICATION.Dto.EvaluationRating;
using APPLICATION.Dto.LikertQuestion;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EvaluationRatingDetail;
public class GetEvaluationRatingDetailDto
{
    public int Id { get; set; }

    public int LikertScaleResponse { get; set; }
    public string QuestionTextResponse { get; set; }

    // Fk EvaluationRating
    public int EvaulationRatingId { get; set; }
    public GetEvaluationRatingDto EvaluationRating { get; set; }

    // Fk LikertQuestion
    public int LikertQuestionId { get; set; }
    public GetLikertQuestionDto LikertQuestion { get; set; }
}
