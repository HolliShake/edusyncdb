using APPLICATION.Dto.Enrollment;
using APPLICATION.Dto.Schedule;
using APPLICATION.Dto.ScheduleTeacher;
using DOMAIN.Model;
using Microsoft.AspNetCore.Mvc;

namespace APPLICATION.IService;
public interface IScheduleTeacherService:IGenericService<ScheduleTeacher, GetScheduleTeacherDto>
{
    public Task<ICollection<GetScheduleDto>> GetScheduleTeacherByUserId(string userId);
    public Task<bool> HasShedule(string userId, int scheduleId);
}
