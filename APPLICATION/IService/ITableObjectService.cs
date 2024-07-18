using APPLICATION.Dto.TableObject;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ITableObjectService:IGenericService<TableObject, GetTableObjectDto>
{
    public Task<ICollection<GetTableObjectDto>> GetParentObject();
    public Task<ICollection<GetTableObjectDto>> GetObjectByAccountGroupId(int accountGroupId);
}
