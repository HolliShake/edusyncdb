
using APPLICATION.Dto.SkillsFrameworkSkillsToCompetency;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkSkillsToCompetencyService:GenericService<SkillsFrameworkSkillsToCompetency, GetSkillsFrameworkSkillsToCompetencyDto>, ISkillsFrameworkSkillsToCompetencyService
{
    public SkillsFrameworkSkillsToCompetencyService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
