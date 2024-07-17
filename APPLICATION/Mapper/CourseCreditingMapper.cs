using AutoMapper;
using APPLICATION.Dto.CourseCrediting;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CourseCreditingMapper : Profile
{
    public CourseCreditingMapper()
    {
        CreateMap<CourseCreditingDto, CourseCrediting>();
        CreateMap<CourseCrediting, GetCourseCreditingDto>();
    }
}
