
using APPLICATION.Dto.Cycle;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface ICycleService:IGenericService<Cycle, GetCycleDto>
{
    public Task<ICollection<GetCycleDto>> GetCycleByCampusId(int campusId);
}
