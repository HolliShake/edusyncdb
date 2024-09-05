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
        return _mapper.Map<ICollection<GetEducationalQualityAssuranceEducationalGoalDto>>(await 
            _dbModel
            .Include(eqaEducationalGoal => eqaEducationalGoal.EqaType)
            .ToListAsync());
    }

    public async new Task<bool> CreateAsync(EducationalQualityAssuranceEducationalGoal newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.EqaType = await _dbContext.EducationalQualityAssuranceTypes.FindAsync(newItem.EqaTypeId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(EducationalQualityAssuranceEducationalGoal updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.EqaType = await _dbContext.EducationalQualityAssuranceTypes.FindAsync(updatedItem.EqaTypeId);
        }
        return result;
    }
}
