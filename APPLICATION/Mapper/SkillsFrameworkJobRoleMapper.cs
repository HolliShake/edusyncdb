using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkJobRole;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkJobRoleMapper : Profile
{
    public SkillsFrameworkJobRoleMapper()
    {
        CreateMap<SkillsFrameworkJobRoleDto, SkillsFrameworkJobRole>();
        CreateMap<SkillsFrameworkJobRole, GetSkillsFrameworkJobRoleDto>();
    }
}
