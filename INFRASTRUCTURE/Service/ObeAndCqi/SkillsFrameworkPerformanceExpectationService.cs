using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkPerformanceExpectation;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkPerformanceExpectationService:GenericService<SkillsFrameworkPerformanceExpectation, GetSkillsFrameworkPerformanceExpectationDto>, ISkillsFrameworkPerformanceExpectationService
{
    public SkillsFrameworkPerformanceExpectationService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
