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
        var gradeBookItems = await _dbModel
        .Include(gbi => gbi.GradeBook)
        .Include(gbi => gbi.GradingPeriod)
        .ToListAsync();
        return _mapper.Map<ICollection<GetGradeBookItemDto>>(gradeBookItems);
    }

    public async new Task<GradeBookItem?> GetAsync(int id)
    {
        var gradeBookItem = await _dbModel
        .Include(gbi => gbi.GradeBook)
        .Include(gbi => gbi.GradingPeriod)
        .Where(gbi => gbi.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return gradeBookItem;
    }

    public async new Task<GetGradeBookItemDto?> CreateAsync(GradeBookItem newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.GradeBook = _dbContext.GradeBooks.Find(newItem.GradeBookId);
            newItem.GradingPeriod = _dbContext.GradingPeriods.Find(newItem.GradingPeriodId);
            return _mapper.Map<GetGradeBookItemDto>(newItem);
        }
        return null;
    }

    public async new Task<GetGradeBookItemDto> UpdateAsync(GradeBookItem updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.GradeBook = _dbContext.GradeBooks.Find(updatedItem.GradeBookId);
            updatedItem.GradingPeriod = _dbContext.GradingPeriods.Find(updatedItem.GradingPeriodId);
            return _mapper.Map<GetGradeBookItemDto>(updatedItem);
        }
        return null;
    }
}
