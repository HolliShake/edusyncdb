using AutoMapper;
using APPLICATION.Dto.AdmissionSchedule;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AdmissionScheduleMapper : Profile
{
    public AdmissionScheduleMapper()
    {
        CreateMap<AdmissionScheduleDto, AdmissionSchedule>();
        CreateMap<AdmissionSchedule, GetAdmissionScheduleDto>();
    }
}
