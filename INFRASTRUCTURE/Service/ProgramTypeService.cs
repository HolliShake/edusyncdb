
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ProgramTypeService:GenericService<ProgramType>, IProgramTypeService
{
    public ProgramTypeService(AppDbContext context):base(context)
    {
    }
}
