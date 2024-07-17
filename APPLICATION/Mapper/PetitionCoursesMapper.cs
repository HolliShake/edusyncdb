using AutoMapper;
using APPLICATION.Dto.PetitionCourses;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class PetitionCoursesMapper : Profile
{
    public PetitionCoursesMapper()
    {
        CreateMap<PetitionCoursesDto, PetitionCourses>();
        CreateMap<PetitionCourses, GetPetitionCoursesDto>();
    }
}
