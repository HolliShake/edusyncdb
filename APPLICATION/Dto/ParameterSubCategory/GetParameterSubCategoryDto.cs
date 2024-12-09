using APPLICATION.Dto.Parameter;
using APPLICATION.Dto.ParameterCategory;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ParameterSubCategory;
public class GetParameterSubCategoryDto
{
    public int Id { get; set; }
    public string ParameterSubCategoryName { get; set; }

    // Fk ParameterCategory
    public int ParameterCategoryId { get; set; }
    public GetParameterCategoryDto ParameterCategory { get; set; }
    // Navigation Properties
    public ICollection<GetParameterDto> Parameters { get; set; }
}
