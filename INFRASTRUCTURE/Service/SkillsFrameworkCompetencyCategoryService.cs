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
        return _mapper.Map<ICollection<GetSkillsFrameworkCompetencyCategoryDto>>(await _dbModel
            .Include(sfcc => sfcc.SfCompetencyType)
            .Include(sfcc => sfcc.SectorDiscipline)
            .ToListAsync());
    }

    public async new Task<SkillsFrameworkCompetencyCategory?> GetAsync(int id)
    {
        return _mapper.Map<SkillsFrameworkCompetencyCategory?>(await _dbModel
            .Include(sfcc => sfcc.SfCompetencyType)
            .Include(sfcc => sfcc.SectorDiscipline)
            .Where(sfcc => sfcc.Id == id).FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(SkillsFrameworkCompetencyCategory newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.SfCompetencyType = await _dbContext.SkillsFrameworkCompetencyTypes.FindAsync(newItem.SfCompetencyTypeId);
            newItem.SectorDiscipline = await _dbContext.SectorDisciplines.FindAsync(newItem.SectorDisciplineId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(SkillsFrameworkCompetencyCategory updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result) 
        {
            updatedItem.SfCompetencyType = await _dbContext.SkillsFrameworkCompetencyTypes.FindAsync(updatedItem.SfCompetencyTypeId);
            updatedItem.SectorDiscipline = await _dbContext.SectorDisciplines.FindAsync(updatedItem.SectorDisciplineId);
        }
        return result;
    }
}
