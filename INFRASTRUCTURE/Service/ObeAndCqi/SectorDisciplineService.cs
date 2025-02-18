using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.SectorDiscipline;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SectorDisciplineService:GenericService<SectorDiscipline, GetSectorDisciplineDto>, ISectorDisciplineService
{
    public SectorDisciplineService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetSectorDisciplineDto>> GetAllAsync()
    {
        var sectorDisciplines = await _dbModel
        .Include(sd => sd.Children)
        .ToListAsync();
        return _mapper.Map<ICollection<GetSectorDisciplineDto>>(sectorDisciplines);
    }

    public async Task<ICollection<GetSectorDisciplineDto>> GetAllParentSectorDiscipline()
    {
        var sectorDisciplines = await _dbModel
        .Include(sd => sd.Children)
        .Where(sd => sd.ParentId == null)
        .ToListAsync();
        return _mapper.Map<ICollection<GetSectorDisciplineDto>>(sectorDisciplines);
    }

    public async Task<ICollection<GetSectorDisciplineDto>> GetSectorDisciplineByParentSectorDisciplineId(int parentId)
    {
        var sectorDisciplines = await _dbModel
        .Where(sd => sd.ParentId != null)
        .Where(sd => sd.ParentId == parentId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetSectorDisciplineDto>>(sectorDisciplines);
    }
}
