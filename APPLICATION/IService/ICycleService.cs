
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICycleService:IGenericService<Cycle>
{
    public Task<ICollection<Cycle>> GetCycleByCampusId(int campusId);
}
