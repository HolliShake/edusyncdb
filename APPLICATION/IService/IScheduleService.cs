
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IScheduleService:IGenericService<Schedule>
{
    public Task<ICollection<Schedule>> GetSchedulesByAcademicProgramId(int academicProgramId);
    public Task<ICollection<Schedule>> GetSchedulesByRoomId(int roomId);
    public Task<ICollection<Schedule>> GetSchedulesByCycleId(int cycleId);
    public Task<ICollection<Schedule>> GetSchedulesByCourseId(int courseId);
}
