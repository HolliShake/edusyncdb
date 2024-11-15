
using APPLICATION.Dto.ScheduleAssignment;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScheduleAssignmentService:GenericService<ScheduleAssignment, GetScheduleAssignmentDto>, IScheduleAssignmentService
{
    public ScheduleAssignmentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
