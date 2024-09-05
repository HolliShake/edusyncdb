using APPLICATION.Dto.AcademicCalendar;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AcademicCalendarService:GenericService<AcademicCalendar, GetAcademicCalendarDto>, IAcademicCalendarService
{
    public AcademicCalendarService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetAcademicCalendarDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetAcademicCalendarDto>>(await 
            _dbModel
            .Include(ac => ac.Cycle)
            .Include(ac => ac.GradingPeriod)
            .ToListAsync());
    }

    public async new Task<GetAcademicCalendarDto?> GetAsync(int id)
    {
        return _mapper.Map<GetAcademicCalendarDto?>(await 
            _dbModel
            .Include(ac => ac.Cycle)
            .Include(ac => ac.GradingPeriod)
            .Where(ac => ac.Id == id).FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(AcademicCalendar newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.Cycle = await _dbContext.Cycles.FindAsync(newItem.CycleId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(AcademicCalendar updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.Cycle = await _dbContext.Cycles.FindAsync(updatedItem.CycleId);
        }
        return result;
    }

    public async Task<ICollection<GetAcademicCalendarDto>> GetAcademicCalendarsByGradingPeriodId(int gradingPeriodId)
    {
        return _mapper.Map<ICollection<GetAcademicCalendarDto>>(await
            _dbModel
            .Include(ac => ac.Cycle)
            .Include(ac => ac.GradingPeriod)
            .Where(ac => ac.GradingPeriodId == gradingPeriodId).ToListAsync());
    }
}
