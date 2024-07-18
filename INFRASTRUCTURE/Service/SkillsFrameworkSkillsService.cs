using APPLICATION.Dto.SkillsFrameworkSkills;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkSkillsService:GenericService<SkillsFrameworkSkills, GetSkillsFrameworkSkillsDto>, ISkillsFrameworkSkillsService
{
    public SkillsFrameworkSkillsService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
