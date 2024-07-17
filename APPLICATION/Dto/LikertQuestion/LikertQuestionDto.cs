using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.LikertQuestion;
public class LikertQuestionDto
{
    public int LikertScale { get; set; }
    public string QuestionText { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsVisible { get; set; }

    // Fk Parameter
    public int ParameterId { get; set; }
}
