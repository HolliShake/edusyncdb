using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAccessListService:IGenericService<AccessList>
{
    public Task<ICollection<AccessList>> GetGroups();
}