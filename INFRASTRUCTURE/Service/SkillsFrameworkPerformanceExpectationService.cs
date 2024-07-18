using APPLICATION.Dto.SkillsFrameworkPerformanceExpectation;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkPerformanceExpectationService:GenericService<SkillsFrameworkPerformanceExpectation, GetSkillsFrameworkPerformanceExpectationDto>, ISkillsFrameworkPerformanceExpectationService
{
    public SkillsFrameworkPerformanceExpectationService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
