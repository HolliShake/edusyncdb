using APPLICATION.Dto.AccessList;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAccessListService:IGenericService<AccessList, GetAccessListDto>
{
    public Task<ICollection<GetAccessListDto>> GetGroups();
}