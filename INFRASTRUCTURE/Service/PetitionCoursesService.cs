
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PetitionCoursesService:GenericService<PetitionCourses>, IPetitionCoursesService
{
    public PetitionCoursesService(AppDbContext context):base(context)
    {
    }
}
