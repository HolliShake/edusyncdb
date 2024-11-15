using APPLICATION.Dto.GradingPeriod;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class GradingPeriodService:GenericService<GradingPeriod, GetGradingPeriodDto>, IGradingPeriodService
{
    public GradingPeriodService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetGradingPeriodDto>> GetAllAsync()
    {
        var gradingPeriods = await _dbModel
        .Include(gp => gp.College)
        .ToListAsync();
        return _mapper.Map<ICollection<GetGradingPeriodDto>>(gradingPeriods);
    }

    public async new Task<GetGradingPeriodDto?> CreateAsync(GradingPeriod newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save()) 
        {
            newItem.College = _dbContext.Colleges.Find(newItem.CollegeId);
            return _mapper.Map<GetGradingPeriodDto>(newItem);
        }
        return null;
    }

    public async new Task<GetGradingPeriodDto?> UpdateAsync(GradingPeriod updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.College = _dbContext.Colleges.Find(updatedItem.CollegeId);
            return _mapper.Map<GetGradingPeriodDto>(updatedItem);
        }
        return null;
    }

    public async Task<ICollection<GetGradingPeriodDto>> GetGradingPeriodByCollegeId(int collegeId)
    {
        var gradingPeriods = await _dbModel
        .Where(g => g.CollegeId == collegeId)
        .ToListAsync();
       return _mapper.Map<ICollection<GetGradingPeriodDto>>(gradingPeriods);
    }
}
