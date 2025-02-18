using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.EducationalQualityAssuranceProgramObjective;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class EducationalQualityAssuranceProgramObjectiveService:GenericService<EducationalQualityAssuranceProgramObjective, GetEducationalQualityAssuranceProgramObjectiveDto>, IEducationalQualityAssuranceProgramObjectiveService
{
    public EducationalQualityAssuranceProgramObjectiveService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetEducationalQualityAssuranceProgramObjectiveDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetEducationalQualityAssuranceProgramObjectiveDto>>(await _dbModel
            .Include(eqapo => eqapo.EqaEducationalGoal)
            .ToListAsync());
    }

    public async new Task<EducationalQualityAssuranceProgramObjective?> GetAsync(int id)
    {
        var eqaProgramObjective = await _dbModel
        .Include(eqapo => eqapo.EqaEducationalGoal)
        .Where(eqapo => eqapo.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return eqaProgramObjective;
    }

    public async new Task<GetEducationalQualityAssuranceProgramObjectiveDto?> CreateAsync(EducationalQualityAssuranceProgramObjective newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.EqaEducationalGoal = _dbContext.EducationalQualityAssuranceEducationalGoals.Find(newItem.EqaEducationalGoalId);
            return _mapper.Map<GetEducationalQualityAssuranceProgramObjectiveDto>(newItem);
        }
        return null;
    }

    public async new Task<GetEducationalQualityAssuranceProgramObjectiveDto?> UpdateAsync(EducationalQualityAssuranceProgramObjective updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.EqaEducationalGoal = _dbContext.EducationalQualityAssuranceEducationalGoals.Find(updatedItem.EqaEducationalGoalId);
            return _mapper.Map<GetEducationalQualityAssuranceProgramObjectiveDto>(updatedItem);
        }
        return null;
    }
}
