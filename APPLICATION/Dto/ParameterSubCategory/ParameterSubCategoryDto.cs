using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ParameterSubCategory;
public class ParameterSubCategoryDto
{
    public string ParameterSubCategoryName { get; set; }

    // Fk ParameterCategory
    public int ParameterCategoryId { get; set; }
}
