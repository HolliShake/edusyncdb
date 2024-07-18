using APPLICATION.Dto.ParameterSubCategory;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ParameterSubCategoryService:GenericService<ParameterSubCategory, GetParameterSubCategoryDto>, IParameterSubCategoryService
{
    public ParameterSubCategoryService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
