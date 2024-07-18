using APPLICATION.Dto.AccessListAction;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAccessListActionService:IGenericService<AccessListAction, GetAccessListActionDto>
{
    public Task<ICollection<GetAccessListActionDto>> GetAccessListActionsByAccessListId(int accessListId);
}
