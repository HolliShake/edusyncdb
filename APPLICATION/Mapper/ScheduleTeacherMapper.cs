using AutoMapper;
using APPLICATION.Dto.ScheduleTeacher;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ScheduleTeacherMapper : Profile
{
    public ScheduleTeacherMapper()
    {
        CreateMap<ScheduleTeacherDto, ScheduleTeacher>();
        CreateMap<ScheduleTeacher, GetScheduleTeacherDto>();
    }
}
