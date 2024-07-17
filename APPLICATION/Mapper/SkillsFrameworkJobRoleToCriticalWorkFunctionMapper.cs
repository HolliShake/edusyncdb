using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkJobRoleToCriticalWorkFunction;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkJobRoleToCriticalWorkFunctionMapper : Profile
{
    public SkillsFrameworkJobRoleToCriticalWorkFunctionMapper()
    {
        CreateMap<SkillsFrameworkJobRoleToCriticalWorkFunctionDto, SkillsFrameworkJobRoleToCriticalWorkFunction>();
        CreateMap<SkillsFrameworkJobRoleToCriticalWorkFunction, GetSkillsFrameworkJobRoleToCriticalWorkFunctionDto>();
    }
}
