
using APPLICATION.Dto.UserAccessGroupDetails;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IUserAccessGroupDetailsService:IGenericService<UserAccessGroupDetails, GetUserAccessGroupDetailsDto>
{
    public Task<ICollection<GetUserAccessGroupDetailsDto>> GetUserAccessGroupByUserGuid(string userGuid);
    public Task<object> GetUserAccessByUserGuid(string userGuid);
    public ICollection<GetUserAccessGroupDetailsDto> GetUserAccessGroupByUserGuidSync(string userGuid);
}
