using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Parameter;
public class ParameterDto
{
    public string ParameterName { get; set; }
    public string QuestionTypeLikertOrText { get; set; }

    // Fk Parameter
    public int? ParentId { get; set; }

    // Fk ParameterSubCategory
    public int ParameterSubCategoryId { get; set; }
}
