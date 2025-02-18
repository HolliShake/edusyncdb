using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkSkills;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkSkillsService:GenericService<SkillsFrameworkSkills, GetSkillsFrameworkSkillsDto>, ISkillsFrameworkSkillsService
{
    public SkillsFrameworkSkillsService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
