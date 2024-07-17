using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkCriticalWorkFunction;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkCriticalWorkFunctionMapper : Profile
{
    public SkillsFrameworkCriticalWorkFunctionMapper()
    {
        CreateMap<SkillsFrameworkCriticalWorkFunctionDto, SkillsFrameworkCriticalWorkFunction>();
        CreateMap<SkillsFrameworkCriticalWorkFunction, GetSkillsFrameworkCriticalWorkFunctionDto>();
    }
}
