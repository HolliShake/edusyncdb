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
        return _mapper.Map<ICollection<GetGradingPeriodDto>>(await _dbModel
            .Include(gp => gp.College)
            .ToListAsync());
    }

    public async new Task<bool> CreateAsync(GradingPeriod newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result) 
        {
            newItem.College = _dbContext.Colleges.Find(newItem.CollegeId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(GradingPeriod updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.College = _dbContext.Colleges.Find(updatedItem.CollegeId);
        }
        return result;
    }

    public async Task<ICollection<GetGradingPeriodDto>> GetGradingPeriodByCollegeId(int collegeId)
    {
       return _mapper.Map<ICollection<GetGradingPeriodDto>>(await _dbModel
            .Where(g => g.CollegeId == collegeId).ToListAsync());
    }
}
