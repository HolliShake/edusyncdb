using APPLICATION.Dto.SectorDiscipline;
using DOMAIN.Model;

namespace APPLICATION.IService.ObeAndCqi;

public interface ISectorDisciplineService:IGenericService<SectorDiscipline, GetSectorDisciplineDto>
{
    public Task<ICollection<GetSectorDisciplineDto>> GetAllParentSectorDiscipline();
    public Task<ICollection<GetSectorDisciplineDto>> GetSectorDisciplineByParentSectorDisciplineId(int parentId);
}
