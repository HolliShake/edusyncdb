using AutoMapper;
using APPLICATION.Dto.Course;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CourseMapper : Profile
{
    public CourseMapper()
    {
        CreateMap<CourseDto, Course>();
        CreateMap<Course, GetCourseDto>();
    }
}
