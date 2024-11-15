using APPLICATION.Dto.SkillsFrameworkCompetencyCategory;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCompetencyCategoryService:GenericService<SkillsFrameworkCompetencyCategory, GetSkillsFrameworkCompetencyCategoryDto>, ISkillsFrameworkCompetencyCategoryService
{
    public SkillsFrameworkCompetencyCategoryService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }


    public async new Task<ICollection<GetSkillsFrameworkCompetencyCategoryDto>> GetAllAsync()
    {
        var sfCompetencyCategory = await _dbModel
        .Include(sfcc => sfcc.SfCompetencyType)
        .Include(sfcc => sfcc.SectorDiscipline)
        .ToListAsync();
        return _mapper.Map<ICollection<GetSkillsFrameworkCompetencyCategoryDto>>(sfCompetencyCategory);
    }

    public async new Task<SkillsFrameworkCompetencyCategory?> GetAsync(int id)
    {
        var sfCompetencyCategory = await _dbModel
        .Include(sfcc => sfcc.SfCompetencyType)
        .Include(sfcc => sfcc.SectorDiscipline)
        .Where(sfcc => sfcc.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return sfCompetencyCategory;
    }

    public async new Task<GetSkillsFrameworkCompetencyCategoryDto?> CreateAsync(SkillsFrameworkCompetencyCategory newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.SfCompetencyType = _dbContext.SkillsFrameworkCompetencyTypes.Find(newItem.SfCompetencyTypeId);
            newItem.SectorDiscipline = _dbContext.SectorDisciplines.Find(newItem.SectorDisciplineId);
            return _mapper.Map<GetSkillsFrameworkCompetencyCategoryDto>(newItem);
        }
        return null;
    }

    public async new Task<GetSkillsFrameworkCompetencyCategoryDto?> UpdateAsync(SkillsFrameworkCompetencyCategory updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save()) 
        {
            updatedItem.SfCompetencyType = _dbContext.SkillsFrameworkCompetencyTypes.Find(updatedItem.SfCompetencyTypeId);
            updatedItem.SectorDiscipline = _dbContext.SectorDisciplines.Find(updatedItem.SectorDisciplineId);
            return _mapper.Map<GetSkillsFrameworkCompetencyCategoryDto>(updatedItem);
        }
        return null;
    }
}
