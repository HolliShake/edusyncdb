using AutoMapper;
using APPLICATION.Dto.PetitionCourses;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class PetitionCoursesService:GenericService<PetitionCourses, GetPetitionCoursesDto>, IPetitionCoursesService
{
    public PetitionCoursesService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
