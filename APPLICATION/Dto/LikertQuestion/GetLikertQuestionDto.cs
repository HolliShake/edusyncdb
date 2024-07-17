using APPLICATION.Dto.Parameter;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.LikertQuestion;
public class GetLikertQuestionDto
{
    public int Id { get; set; }
    public int LikertScale { get; set; }
    public string QuestionText { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsVisible { get; set; }

    // Fk Parameter
    public int ParameterId { get; set; }
    public GetParameterDto Parameter { get; set; }
}
