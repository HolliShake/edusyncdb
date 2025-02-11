using APPLICATION.Dto.Schedule;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IScheduleService:IGenericService<Schedule, GetScheduleDto>
{

    //================
    public Task<object> GetScheduleByRoom(int roomId);
    public Task<bool> CreateAllWithUserIdAsync(string userId, List<Schedule> newItems);
    public Task<ICollection<GetScheduleDto>> GetByCreatedByUserId(string createdByUserId);
    public Task<object> GetSchedulesByCampusId(int campusId);
    public Task<object> GetSchedulesByCampusAndCycleId(int campusId, int cycleId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesBySectionNameAndCycleId(string sectionName, int cycleId);
    public Task<object> GetSchedulesByCurriculumAndCycleIdAndYearLevel(int curriculumId, int cycleId, int yearLevel);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByAcademicProgramId(int academicProgramId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByCycleId(int cycleId);
    public Task<ICollection<GetScheduleDto>> GetSchedulesByCourseId(int courseId);
    public Task<object?> GenerateSchedule(string generatedByUserId, int numberOfSchedules, ScheduleGenerateDto schedules);
    public Task<GetScheduleDto?> AddAnotherSchedule(string generatedReference);
    public Task<object?> AddSection(string generatedByUserId, ScheduleGenerateDto schedules);
    public Task<bool> DeleteSectionBySectionNameAndCycleId(string sectionName, int cycleId);
}
