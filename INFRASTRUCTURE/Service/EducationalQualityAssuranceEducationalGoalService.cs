using APPLICATION.Dto.EducationalQualityAssuranceEducationalGoal;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceEducationalGoalService:GenericService<EducationalQualityAssuranceEducationalGoal, GetEducationalQualityAssuranceEducationalGoalDto>, IEducationalQualityAssuranceEducationalGoalService
{
    public EducationalQualityAssuranceEducationalGoalService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetEducationalQualityAssuranceEducationalGoalDto>> GetAllAsync()
    {
        var eqaEducationalGoals = await 
            _dbModel
            .Include(eqaEducationalGoal => eqaEducationalGoal.EqaType)
            .ToListAsync();
        return _mapper.Map<ICollection<GetEducationalQualityAssuranceEducationalGoalDto>>(eqaEducationalGoals);
    }

    public async new Task<GetEducationalQualityAssuranceEducationalGoalDto?> CreateAsync(EducationalQualityAssuranceEducationalGoal newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.EqaType = _dbContext.EducationalQualityAssuranceTypes.Find(newItem.EqaTypeId);
            return _mapper.Map<GetEducationalQualityAssuranceEducationalGoalDto>(newItem);
        }
        return null;
    }

    public async new Task<GetEducationalQualityAssuranceEducationalGoalDto?> UpdateAsync(EducationalQualityAssuranceEducationalGoal updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.EqaType = _dbContext.EducationalQualityAssuranceTypes.Find(updatedItem.EqaTypeId);
            return _mapper.Map<GetEducationalQualityAssuranceEducationalGoalDto>(updatedItem);
        }
        return null;
    }
}
