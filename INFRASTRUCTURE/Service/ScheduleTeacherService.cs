
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScheduleTeacherService:GenericService<ScheduleTeacher>, IScheduleTeacherService
{
    public ScheduleTeacherService(AppDbContext context):base(context)
    {
    }
}
