using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkCriticalWorkFunction;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkCriticalWorkFunctionService:GenericService<SkillsFrameworkCriticalWorkFunction, GetSkillsFrameworkCriticalWorkFunctionDto>, ISkillsFrameworkCriticalWorkFunctionService
{
    public SkillsFrameworkCriticalWorkFunctionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
