
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ITableObjectService:IGenericService<TableObject>
{
    public Task<ICollection<TableObject>> GetParentObject();
    public Task<ICollection<TableObject>> GetObjectByAccountGroupId(int accountGroupId);
}
