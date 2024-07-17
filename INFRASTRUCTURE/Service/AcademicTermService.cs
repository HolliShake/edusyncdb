
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AcademicTermService:GenericService<AcademicTerm>, IAcademicTermService
{
    public AcademicTermService(AppDbContext context):base(context)
    {
    }
}
