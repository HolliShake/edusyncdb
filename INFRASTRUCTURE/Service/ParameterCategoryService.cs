
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ParameterCategoryService:GenericService<ParameterCategory>, IParameterCategoryService
{
    public ParameterCategoryService(AppDbContext context):base(context)
    {
    }
}
