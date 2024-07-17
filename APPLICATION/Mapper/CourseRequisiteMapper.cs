using AutoMapper;
using APPLICATION.Dto.CourseRequisite;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CourseRequisiteMapper : Profile
{
    public CourseRequisiteMapper()
    {
        CreateMap<CourseRequisiteDto, CourseRequisite>();
        CreateMap<CourseRequisite, GetCourseRequisiteDto>();
    }
}
