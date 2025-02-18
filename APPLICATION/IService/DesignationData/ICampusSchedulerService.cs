using APPLICATION.Dto.Campus;
using APPLICATION.Dto.CampusScheduler;
using DOMAIN.Model;

namespace APPLICATION.IService.DesignationData;

public interface ICampusSchedulerService:IGenericService<CampusScheduler, GetCampusSchedulerDto>
{
    public Task<bool> IsScheduler(string userId);
    public Task<GetCampusDto> GetScheduleByUserId(string userId);
    public Task<ICollection<GetCampusDto>> GetCampusesByUserId(string userId);
    public Task<object> GetBuildingWithinRoomsSchedulesByUserAndCampusId(string userId, int campusId);
    public Task<object> GetMergedSchedulesBySchedulerUserAndCampusId(string userId, int campusId);
    public Task<object> GetClassScheduleBySchedulerUserAndCampusId(string userId, int campusId);
    public Task<object> GetExamScheduleBySchedulerUserAndCampusId(string userId, int campusId);
}
