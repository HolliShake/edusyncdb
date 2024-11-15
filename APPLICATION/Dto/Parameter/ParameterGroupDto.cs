using APPLICATION.Dto.LikertQuestion;

namespace APPLICATION.Dto.Parameter;

public class ParameterGroupDto
{
    public string ParameterName { get; set; }
    public bool QuestionTypeLikertOrText { get; set; }

    // Fk Parameter
    public int? ParentId { get; set; }

    public List<LikertQuestionGroupDto> likertQuestions { get; set; }
}