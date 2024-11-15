namespace DOMAIN.Model;

public class EvaluationRatingDetail
{
    public int Id { get; set; }

    public int LikertScaleResponse { get; set; }
    public string QuestionTextResponse { get; set; }

    // Fk EvaluationRating
    public int EvaluationRatingId { get; set; }
    public EvaluationRating EvaluationRating { get; set; }

    // Fk LikertQuestion
    public int LikertQuestionId { get; set; }
    public LikertQuestion LikertQuestion { get; set; }
}