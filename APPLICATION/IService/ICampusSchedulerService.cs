
using APPLICATION.Dto.Campus;
using APPLICATION.Dto.CampusScheduler;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICampusSchedulerService:IGenericService<CampusScheduler, GetCampusSchedulerDto>
{
    public Task<ICollection<GetCampusDto>> GetCampusesByUserId(string userId);
    public Task<object> GetMergedSchedulesBySchedulerUserAndCampusId(string userId, int campusId);
    public Task<object> GetClassScheduleBySchedulerUserAndCampusId(string userId, int campusId);
    public Task<object> GetExamScheduleBySchedulerUserAndCampusId(string userId, int campusId);
}
