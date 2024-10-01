using APPLICATION.Dto.Schedule;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IScheduleService:IGenericService<Schedule, GetScheduleDto>
{
    public Task<ICollection<GetScheduleDto>> GetSectionsBySectionNameAndCycleId(string sectionName, int cycleId);
    public Task<bool> CreateAllWithUserIdAsync(string userId, IList<Schedule> newItems);
    public Task<ICollection<GetScheduleDto>> GetByCreatedByUserId(string createdByUserId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByAcademicProgramId(int academicProgramId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByRoomId(int roomId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByCycleId(int cycleId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByCourseId(int courseId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByCampusId(int campusId);
    public Task<ICollection<GetScheduleDto>?> GenerateSchedule(string generatedByUserId, int numberOfSchedules, ScheduleGenerateDto schedules);
}
