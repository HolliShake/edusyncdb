
using APPLICATION.Dto.SectorDiscipline;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class SectorDisciplineService:GenericService<SectorDiscipline, GetSectorDisciplineDto>, ISectorDisciplineService
{
    public SectorDisciplineService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetSectorDisciplineDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetSectorDisciplineDto>>(
            await _dbModel.Include(sd => sd.Children).ToListAsync()
        );
    }

    public async Task<ICollection<GetSectorDisciplineDto>> GetAllParentSectorDiscipline()
    {
        return _mapper.Map<ICollection<GetSectorDisciplineDto>>(await _dbModel
           .Include(sd => sd.Children)
           .Where(sd => sd.ParentId == null)
           .ToListAsync());
    }
    public async Task<ICollection<GetSectorDisciplineDto>> GetSectorDisciplineByParentSectorDisciplineId(int parentId)
    {
        return _mapper.Map<ICollection<GetSectorDisciplineDto>>(await _dbModel
            .Where(sd => sd.ParentId != null)
            .Where(sd => sd.ParentId == parentId)
            .ToListAsync());
    }
}
