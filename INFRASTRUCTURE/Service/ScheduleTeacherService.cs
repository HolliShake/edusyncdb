using APPLICATION.Dto.ScheduleTeacher;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ScheduleTeacherService:GenericService<ScheduleTeacher, GetScheduleTeacherDto>, IScheduleTeacherService
{
    public ScheduleTeacherService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
