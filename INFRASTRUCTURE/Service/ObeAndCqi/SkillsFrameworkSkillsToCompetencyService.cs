using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkSkillsToCompetency;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkSkillsToCompetencyService:GenericService<SkillsFrameworkSkillsToCompetency, GetSkillsFrameworkSkillsToCompetencyDto>, ISkillsFrameworkSkillsToCompetencyService
{
    public SkillsFrameworkSkillsToCompetencyService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
