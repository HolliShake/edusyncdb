using APPLICATION.Dto.AcademicCalendar;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAcademicCalendarService:IGenericService<AcademicCalendar, GetAcademicCalendarDto>
{
    public Task<ICollection<GetAcademicCalendarDto>> GetAcademicCalendarsByGradingPeriodId(int graadingPeriodId);
    public Task<ICollection<GetAcademicCalendarDto>> GetAcademicCalendarsByCampusId(int campusId);
}
