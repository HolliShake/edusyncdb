using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkJobRoleToCriticalWorkFunction;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkJobRoleToCriticalWorkFunctionService:GenericService<SkillsFrameworkJobRoleToCriticalWorkFunction, GetSkillsFrameworkJobRoleToCriticalWorkFunctionDto>, ISkillsFrameworkJobRoleToCriticalWorkFunctionService
{
    public SkillsFrameworkJobRoleToCriticalWorkFunctionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
