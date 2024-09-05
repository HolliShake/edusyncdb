
using APPLICATION.Dto.Agency;
using APPLICATION.Dto.UserAccess;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAgencyService:IGenericService<Agency, GetAgencyDto>
{
    public Task<ICollection<GetAgencyDto>> GetMyAccessibleAgencies(ICollection<UserAccessGroupedBy> accessGroup);
}
