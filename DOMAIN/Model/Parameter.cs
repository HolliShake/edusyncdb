namespace DOMAIN.Model;

public class Parameter
{
    public int Id { get; set; }
    public string ParameterName { get; set; }
    public bool QuestionTypeLikertOrText { get; set; }

    // Fk Parameter
    public int? ParentId { get; set; }
    public Parameter? Parent { get; set; }

    // Fk ParameterSubCategory
    public int ParameterSubCategoryId { get; set; }
    public ParameterSubCategory ParameterSubCategory { get; set; }

    // Navigation Properties
    public ICollection<LikertQuestion> LikertQuestions { get; set; }

}