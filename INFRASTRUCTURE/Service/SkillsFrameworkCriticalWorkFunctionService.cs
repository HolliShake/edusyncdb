using APPLICATION.Dto.SkillsFrameworkCriticalWorkFunction;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCriticalWorkFunctionService:GenericService<SkillsFrameworkCriticalWorkFunction, GetSkillsFrameworkCriticalWorkFunctionDto>, ISkillsFrameworkCriticalWorkFunctionService
{
    public SkillsFrameworkCriticalWorkFunctionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
