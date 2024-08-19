
using APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkTrackSpecializationService:GenericService<SkillsFrameworkTrackSpecialization, GetSkillsFrameworkTrackSpecializationDto>, ISkillsFrameworkTrackSpecializationService
{
    public SkillsFrameworkTrackSpecializationService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetSkillsFrameworkTrackSpecializationDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetSkillsFrameworkTrackSpecializationDto>>(await _dbModel
                .Include(ts => ts.SectorDiscipline)
                .ToListAsync()
        );
    }

    public async new Task<bool> CreateAsync(SkillsFrameworkTrackSpecialization newItem)
    {
        if (newItem.SectorDisciplineId != 0)
        {
            newItem.SectorDiscipline = await _dbContext.SectorDisciplines.FindAsync(newItem.SectorDisciplineId);
        }
        await _dbModel.AddAsync(newItem);
        return await Save();
    }

    public async new Task<bool> UpdateSync(SkillsFrameworkTrackSpecialization updatedItem)
    {
        if (updatedItem.SectorDisciplineId != 0)
        {
            updatedItem.SectorDiscipline = await _dbContext.SectorDisciplines.FindAsync(updatedItem.SectorDisciplineId);
        }

        _dbModel.Update(updatedItem);
        return await Save();
    }

    public async Task<ICollection<GetSkillsFrameworkTrackSpecializationDto>> GetSkillsFrameworkTrackSpecializationsBySectorDisciplineId(int sectorDisciplineId)
    {
        return _mapper.Map<ICollection<GetSkillsFrameworkTrackSpecializationDto>>(await _dbModel
            .Include(sfts => sfts.SectorDiscipline)
            .Where(sfts => sfts.SectorDisciplineId == sectorDisciplineId)
            .ToListAsync());
    }
}
