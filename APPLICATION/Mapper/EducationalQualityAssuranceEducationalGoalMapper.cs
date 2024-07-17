using AutoMapper;
using APPLICATION.Dto.EducationalQualityAssuranceEducationalGoal;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EducationalQualityAssuranceEducationalGoalMapper : Profile
{
    public EducationalQualityAssuranceEducationalGoalMapper()
    {
        CreateMap<EducationalQualityAssuranceEducationalGoalDto, EducationalQualityAssuranceEducationalGoal>();
        CreateMap<EducationalQualityAssuranceEducationalGoal, GetEducationalQualityAssuranceEducationalGoalDto>();
    }
}
