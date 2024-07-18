using APPLICATION.Dto.SkillsFrameworkJobRoleToCriticalWorkFunction;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkJobRoleToCriticalWorkFunctionService:GenericService<SkillsFrameworkJobRoleToCriticalWorkFunction, GetSkillsFrameworkJobRoleToCriticalWorkFunctionDto>, ISkillsFrameworkJobRoleToCriticalWorkFunctionService
{
    public SkillsFrameworkJobRoleToCriticalWorkFunctionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
