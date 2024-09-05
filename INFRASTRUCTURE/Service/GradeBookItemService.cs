using APPLICATION.Dto.GradeBookItem;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class GradeBookItemService:GenericService<GradeBookItem, GetGradeBookItemDto>, IGradeBookItemService
{
    public GradeBookItemService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetGradeBookItemDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetGradeBookItemDto>>(await _dbModel
            .Include(gbi => gbi.GradeBook)
            .Include(gbi => gbi.GradingPeriod)
            .ToListAsync());
    }

    public async new Task<GetGradeBookItemDto?> GetAsync(int id)
    {
        return _mapper.Map<GetGradeBookItemDto?>(await _dbModel
            .Include(gbi => gbi.GradeBook)
            .Include(gbi => gbi.GradingPeriod)
            .Where(gbi => gbi.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(GradeBookItem newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.GradeBook = await _dbContext.GradeBooks.FindAsync(newItem.GradeBookId);
            newItem.GradingPeriod = await _dbContext.GradingPeriods.FindAsync(newItem.GradingPeriodId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(GradeBookItem updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.GradeBook = await _dbContext.GradeBooks.FindAsync(updatedItem.GradeBookId);
            updatedItem.GradingPeriod = await _dbContext.GradingPeriods.FindAsync(updatedItem.GradingPeriodId);
        }
        return result;
    }
}
