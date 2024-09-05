using APPLICATION.Dto.Schedule;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IScheduleService:IGenericService<Schedule, GetScheduleDto>
{
    public Task<ICollection<GetScheduleDto>> GetByCreatedByUserId(string createdByUserId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByAcademicProgramId(int academicProgramId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByRoomId(int roomId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByCycleId(int cycleId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByCourseId(int courseId);
    public Task<ICollection<GetScheduleDto>?> GenerateSchedule(string generatedByUserId, List<ScheduleDto> schedules);
}
