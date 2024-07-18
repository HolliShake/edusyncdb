using APPLICATION.Dto.SkillsFrameworkProficiencyLevel;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkProficiencyLevelService:GenericService<SkillsFrameworkProficiencyLevel, GetSkillsFrameworkProficiencyLevelDto>, ISkillsFrameworkProficiencyLevelService
{
    public SkillsFrameworkProficiencyLevelService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
