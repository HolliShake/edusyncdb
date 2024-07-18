using APPLICATION.Dto.ParameterCategory;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ParameterCategoryService:GenericService<ParameterCategory, GetParameterCategoryDto>, IParameterCategoryService
{
    public ParameterCategoryService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
