
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AcademicProgramService:GenericService<AcademicProgram>, IAcademicProgramService
{
    public AcademicProgramService(AppDbContext context):base(context)
    {
    }
}
