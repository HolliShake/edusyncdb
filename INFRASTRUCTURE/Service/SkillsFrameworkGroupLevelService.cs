using APPLICATION.Dto.SkillsFrameworkGroupLevel;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkGroupLevelService:GenericService<SkillsFrameworkGroupLevel, GetSkillsFrameworkGroupLevelDto>, ISkillsFrameworkGroupLevelService
{
    public SkillsFrameworkGroupLevelService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
