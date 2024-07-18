using APPLICATION.Dto.PetitionCourses;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class PetitionCoursesService:GenericService<PetitionCourses, GetPetitionCoursesDto>, IPetitionCoursesService
{
    public PetitionCoursesService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
