using AutoMapper;
using APPLICATION.Dto.AdmissionEvaluationSchedule;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AdmissionEvaluationScheduleMapper : Profile
{
    public AdmissionEvaluationScheduleMapper()
    {
        CreateMap<AdmissionEvaluationScheduleDto, AdmissionEvaluationSchedule>();
        CreateMap<AdmissionEvaluationSchedule, GetAdmissionEvaluationScheduleDto>();
    }
}
