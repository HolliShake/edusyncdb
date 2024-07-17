using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkPerformanceExpectation;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkPerformanceExpectationMapper : Profile
{
    public SkillsFrameworkPerformanceExpectationMapper()
    {
        CreateMap<SkillsFrameworkPerformanceExpectationDto, SkillsFrameworkPerformanceExpectation>();
        CreateMap<SkillsFrameworkPerformanceExpectation, GetSkillsFrameworkPerformanceExpectationDto>();
    }
}
