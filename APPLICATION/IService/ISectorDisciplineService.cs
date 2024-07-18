using APPLICATION.Dto.SectorDiscipline;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ISectorDisciplineService:IGenericService<SectorDiscipline, GetSectorDisciplineDto>
{
    public Task<ICollection<GetSectorDisciplineDto>> GetAllParentSectorDiscipline();
    public Task<ICollection<GetSectorDisciplineDto>> GetSectorDisciplineByParentSectorDisciplineId(int parentId);
}
