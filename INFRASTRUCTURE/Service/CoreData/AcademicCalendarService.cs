using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.AcademicCalendar;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class AcademicCalendarService:GenericService<AcademicCalendar, GetAcademicCalendarDto>, IAcademicCalendarService
{
    public AcademicCalendarService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetAcademicCalendarDto>> GetAllAsync()
    {
        var academicCalendars = await _dbModel
        .Include(ac => ac.Cycle)
        .Include(ac => ac.GradingPeriod)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAcademicCalendarDto>>(academicCalendars);
    }

    public async Task<ICollection<GetAcademicCalendarDto>> GetAcademicCalendarsByCampusId(int campusId)
    {
        var academicCalendars = await _dbModel
        .Include(ac => ac.Cycle)
        .Include(ac => ac.GradingPeriod)
        .Where(ac => ac.Cycle.CampusId == campusId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAcademicCalendarDto>>(academicCalendars);
    }

    public async new Task<AcademicCalendar?> GetAsync(int id)
    {
        var academicCalendar = await _dbModel
        .Include(ac => ac.Cycle)
        .Include(ac => ac.GradingPeriod)
        .Where(ac => ac.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return academicCalendar;
    }

    public async new Task<GetAcademicCalendarDto?> CreateAsync(AcademicCalendar newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.Cycle = await _dbContext.Cycles.FindAsync(newItem.CycleId);
            newItem.GradingPeriod = await _dbContext.GradingPeriods.FindAsync(newItem.GradingPeriodId);
            return _mapper.Map<GetAcademicCalendarDto>(newItem);
        }
        return null;
    }

    public async new Task<GetAcademicCalendarDto?> UpdateAsync(AcademicCalendar updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.Cycle = await _dbContext.Cycles.FindAsync(updatedItem.CycleId);
            updatedItem.GradingPeriod = await _dbContext.GradingPeriods.FindAsync(updatedItem.GradingPeriodId);
            return _mapper.Map<GetAcademicCalendarDto>(updatedItem);
        }
        return null;
    }

    public async Task<ICollection<GetAcademicCalendarDto>> GetAcademicCalendarsByGradingPeriodId(int gradingPeriodId)
    {
        var academicCalendars = await _dbModel
        .Include(ac => ac.Cycle)
        .Include(ac => ac.GradingPeriod)
        .Where(ac => ac.GradingPeriodId == gradingPeriodId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAcademicCalendarDto>>(academicCalendars);
    }
}
