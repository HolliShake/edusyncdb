
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IUserAccessService:IGenericService<UserAccess>
{
    public Task<ICollection<UserAccess>> GetUserAccessByUserId(string userId);

    public Task<bool> CreateUserAccess(string userId, int accessListId, int accessListActionId);
}
