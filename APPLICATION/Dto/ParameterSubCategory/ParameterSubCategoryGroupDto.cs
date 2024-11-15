
using APPLICATION.Dto.Parameter;

namespace APPLICATION.Dto.ParameterSubCategory;

public class ParameterSubCategoryGroupDto
{
    public string ParameterSubCategoryName { get; set; }
    public List<ParameterGroupDto> ParameterGroups { get; set; }
}
