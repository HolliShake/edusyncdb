
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAccessListActionService:IGenericService<AccessListAction>
{
    public Task<ICollection<AccessListAction>> GetAccessListActionsByAccessListId(int accessListId);
}
