
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AcademicCalendarService:GenericService<AcademicCalendar>, IAcademicCalendarService
{
    public AcademicCalendarService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<AcademicCalendar>> GetAcademicCalendarsByGradingPeriodId(int gradingPeriodId)
    {
        return await _dbModel.Where(ac => ac.GradingPeriodId == gradingPeriodId).ToListAsync();
    }
}
