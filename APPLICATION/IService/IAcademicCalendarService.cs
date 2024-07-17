using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAcademicCalendarService:IGenericService<AcademicCalendar>
{
    public Task<ICollection<AcademicCalendar>> GetAcademicCalendarsByGradingPeriodId(int graadingPeriodId);
}
