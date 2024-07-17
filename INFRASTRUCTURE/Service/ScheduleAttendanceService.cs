
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScheduleAttendanceService:GenericService<ScheduleAttendance>, IScheduleAttendanceService
{
    public ScheduleAttendanceService(AppDbContext context):base(context)
    {
    }
}
