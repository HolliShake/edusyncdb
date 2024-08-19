
using DOMAIN.Model;
using APPLICATION.Dto.UserAccess;

namespace APPLICATION.IService;
public interface IUserAccessService:IGenericService<UserAccess, GetUserAccessDto>
{
    public Task<ICollection<GetUserAccessDto>> GetUserAccessByUserId(string userId);

    public Task<bool> CreateUserAccess(string userId, int accessListId, int accessListActionId);
    public Task<List<GetUserAccessDto>> UpdateUserAccess(List<UpdateUserAccessDto> items);
}
