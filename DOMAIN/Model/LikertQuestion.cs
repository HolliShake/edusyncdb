namespace DOMAIN.Model;

public class LikertQuestion
{
    public int Id { get; set; }
    public int LikertScale { get; set; }
    public string QuestionText { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsVisible { get; set; }

    // Fk Parameter
    public int ParameterId { get; set; }
    public Parameter Parameter { get; set; }
}