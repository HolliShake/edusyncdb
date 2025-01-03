
using APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
using APPLICATION.Dto.SpecializationChair;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ISpecializationChairService:IGenericService<SpecializationChair, GetSpecializationChairDto>
{
    public Task<GetSkillsFrameworkTrackSpecializationDto> GetTrackSpecializationByUserId(string userId);

    public Task<object> GetAllPendingCourseCrediting(string userId, int trackSpecializationId);

    public Task<object> GetAllApprovedCourseCrediting(string userId, int trackSpecializationId);

    public Task<object> GetAllRejectedCourseCrediting(string userId, int trackSpecializationId);

    public Task<object> GetAllReturnedCourseCrediting(string userId, int trackSpecializationId);
    public Task<object> GetAllCurriculumBySfTrackSpecialization(int trackSpecializationId);
}
