using AutoMapper;
using APPLICATION.Dto.ScheduleAssignment;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ScheduleAssignmentMapper : Profile
{
    public ScheduleAssignmentMapper()
    {
        CreateMap<ScheduleAssignmentDto, ScheduleAssignment>();
        CreateMap<ScheduleAssignment, GetScheduleAssignmentDto>();
    }
}
