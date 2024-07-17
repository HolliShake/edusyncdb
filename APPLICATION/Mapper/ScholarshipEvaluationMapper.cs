using AutoMapper;
using APPLICATION.Dto.ScholarshipEvaluation;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ScholarshipEvaluationMapper : Profile
{
    public ScholarshipEvaluationMapper()
    {
        CreateMap<ScholarshipEvaluationDto, ScholarshipEvaluation>();
        CreateMap<ScholarshipEvaluation, GetScholarshipEvaluationDto>();
    }
}
