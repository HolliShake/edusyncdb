using APPLICATION.Dto.ScheduleAttendance;
using DOMAIN.Model;
using Microsoft.AspNetCore.Http;

namespace APPLICATION.IService.SchedulingData;

public interface IScheduleAttendanceService:IGenericService<ScheduleAttendance, GetScheduleAttendanceDto>
{
    public Task<object> GetAttendanceByAnyUserId(string userId);
    public Task<object?> SubmitAttendance(string userId, bool isTimeIn, int scheduleId, IFormFile file);
}
