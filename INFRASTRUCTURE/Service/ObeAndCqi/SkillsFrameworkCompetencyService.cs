using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkCompetency;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkCompetencyService:GenericService<SkillsFrameworkCompetency, GetSkillsFrameworkCompetencyDto>, ISkillsFrameworkCompetencyService
{
    public SkillsFrameworkCompetencyService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
