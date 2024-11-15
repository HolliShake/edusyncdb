
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
        var sfTrackSpecialization = await _dbModel
        .Include(ts => ts.SectorDiscipline)
        .ToListAsync();
        return _mapper.Map<ICollection<GetSkillsFrameworkTrackSpecializationDto>>(sfTrackSpecialization);
    }

    public async new Task<GetSkillsFrameworkTrackSpecializationDto?> CreateAsync(SkillsFrameworkTrackSpecialization newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.SectorDiscipline = _dbContext.SectorDisciplines.Find(newItem.SectorDisciplineId);
            return _mapper.Map<GetSkillsFrameworkTrackSpecializationDto>(newItem);
        }
        return null;
    }

    public async new Task<GetSkillsFrameworkTrackSpecializationDto?> UpdateAsync(SkillsFrameworkTrackSpecialization updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.SectorDiscipline = _dbContext.SectorDisciplines.Find(updatedItem.SectorDisciplineId);
            return _mapper.Map<GetSkillsFrameworkTrackSpecializationDto>(updatedItem);
        }
        return null;
    }

    public async Task<ICollection<GetSkillsFrameworkTrackSpecializationDto>> GetSkillsFrameworkTrackSpecializationsBySectorDisciplineId(int sectorDisciplineId)
    {
        var sfTrackSpecialization = await _dbModel
        .Include(sfts => sfts.SectorDiscipline)
        .Where(sfts => sfts.SectorDisciplineId == sectorDisciplineId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetSkillsFrameworkTrackSpecializationDto>>(sfTrackSpecialization);
    }
}
