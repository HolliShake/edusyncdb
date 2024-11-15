using APPLICATION.Dto.ParameterSubCategory;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Parameter;
public class GetParameterDto
{
    public int Id { get; set; }
    public string ParameterName { get; set; }
    public bool QuestionTypeLikertOrText { get; set; }

    // Fk Parameter
    public int? ParentId { get; set; }
    public GetParameterDto? Parent { get; set; }

    // Fk ParameterSubCategory
    public int ParameterSubCategoryId { get; set; }
    public GetParameterSubCategoryDto ParameterSubCategory { get; set; }

}
