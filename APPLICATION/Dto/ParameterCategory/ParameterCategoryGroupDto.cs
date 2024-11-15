using APPLICATION.Dto.ParameterSubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.Dto.ParameterCategory;

public class ParameterCategoryGroupDto
{
    public string ParameterCategoryName { get; set; }
    public List<ParameterSubCategoryGroupDto> ParameterSubCategories { get; set; }
}