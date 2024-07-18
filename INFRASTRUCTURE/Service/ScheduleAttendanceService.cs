using APPLICATION.Dto.ScheduleAttendance;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScheduleAttendanceService:GenericService<ScheduleAttendance, GetScheduleAttendanceDto>, IScheduleAttendanceService
{
    public ScheduleAttendanceService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
