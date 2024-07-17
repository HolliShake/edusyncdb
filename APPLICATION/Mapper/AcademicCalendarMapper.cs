using AutoMapper;
using APPLICATION.Dto.AcademicCalendar;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AcademicCalendarMapper : Profile
{
    public AcademicCalendarMapper()
    {
        CreateMap<AcademicCalendarDto, AcademicCalendar>();
        CreateMap<AcademicCalendar, GetAcademicCalendarDto>();
    }
}
