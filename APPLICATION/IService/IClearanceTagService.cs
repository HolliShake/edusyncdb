using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IClearanceTagService:IGenericService<ClearanceTag>
{
    public Task<ICollection<ClearanceTag>> GetClearanceTagsByClearanceTypeId(int clearanceTypeId);
}
