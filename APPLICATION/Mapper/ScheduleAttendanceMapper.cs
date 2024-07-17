using AutoMapper;
using APPLICATION.Dto.ScheduleAttendance;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ScheduleAttendanceMapper : Profile
{
    public ScheduleAttendanceMapper()
    {
        CreateMap<ScheduleAttendanceDto, ScheduleAttendance>();
        CreateMap<ScheduleAttendance, GetScheduleAttendanceDto>();
    }
}
