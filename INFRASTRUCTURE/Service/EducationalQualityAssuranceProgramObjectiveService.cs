using APPLICATION.Dto.EducationalQualityAssuranceProgramObjective;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
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

    public async new Task<GetEducationalQualityAssuranceProgramObjectiveDto?> GetAsync(int id)
    {
        return _mapper.Map<GetEducationalQualityAssuranceProgramObjectiveDto?>(await _dbModel
            .Include(eqapo => eqapo.EqaEducationalGoal)
            .Where(eqapo => eqapo.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(EducationalQualityAssuranceProgramObjective newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.EqaEducationalGoal = await _dbContext.EducationalQualityAssuranceEducationalGoals.FindAsync(newItem.EqaEducationalGoalId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(EducationalQualityAssuranceProgramObjective updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.EqaEducationalGoal = await _dbContext.EducationalQualityAssuranceEducationalGoals.FindAsync(updatedItem.EqaEducationalGoalId);
        }
        return result;
    }
}
