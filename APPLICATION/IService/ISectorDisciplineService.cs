
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ISectorDisciplineService:IGenericService<SectorDiscipline>
{
    public Task<ICollection<SectorDiscipline>> GetAllParentSectorDiscipline();
    public Task<ICollection<SectorDiscipline>> GetSectorDisciplineByParentSectorDisciplineId(int parentId);
}
