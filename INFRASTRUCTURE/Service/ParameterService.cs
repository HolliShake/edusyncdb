
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ParameterService:GenericService<Parameter>, IParameterService
{
    public ParameterService(AppDbContext context):base(context)
    {
    }
}
