using DOMAIN.Model;
using APPLICATION.Dto.CourseCrediting;

namespace APPLICATION.IService.CourseCatalogData;

public interface ICourseCreditingService:IGenericService<CourseCrediting, GetCourseCreditingDto>
{
    public Task<object> ApproveByUserAndId(string userId, int courseCreditingId);
    public Task<object> RejectByUserAndId(string userId, int courseCreditingId);
    public Task<object> ReturnByUserAndId(string userId, int courseCreditingId);
    public Task<object> RevertByUserAndId(string userId, int courseCreditingId);
    public Task<object> GetCourseCreditingByStatusAndAssignToUserId(GlobalValidityStatusEnum status, string userId);
}
