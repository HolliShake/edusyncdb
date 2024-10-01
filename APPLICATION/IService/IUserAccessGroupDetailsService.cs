
using APPLICATION.Dto.UserAccessGroupDetails;
using APPLICATION.Dto.UserCampusDetails;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IUserAccessGroupDetailsService:IGenericService<UserAccessGroupDetails, GetUserAccessGroupDetailsDto>
{
    public Task<ICollection<GetUserAccessGroupDetailsDto>> GetUserAccessGroupByUserGuid(string userGuid);
    public Task<object> GetUserAccessByUserGuid(string userGuid);
    public ICollection<GetUserAccessGroupDetailsDto> GetUserAccessGroupByUserGuidSync(string userGuid);
    public Task<object?> CreateMultipleUserAccess(UserCampusDetailMultipleAccessGroupActionDto item);
    public Task<bool> DeleteMultipleUserAccess(UserCampusDetailMultipleAccessGroupActionDto item);
}
