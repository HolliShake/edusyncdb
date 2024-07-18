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

    public async Task<ICollection<GetAcademicCalendarDto>> GetAcademicCalendarsByGradingPeriodId(int gradingPeriodId)
    {
        return _mapper.Map<ICollection<GetAcademicCalendarDto>>(await _dbModel.Where(ac => ac.GradingPeriodId == gradingPeriodId).ToListAsync());
    }
}
