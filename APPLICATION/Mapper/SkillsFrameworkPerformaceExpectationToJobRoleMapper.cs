using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkPerformaceExpectationToJobRole;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkPerformaceExpectationToJobRoleMapper : Profile
{
    public SkillsFrameworkPerformaceExpectationToJobRoleMapper()
    {
        CreateMap<SkillsFrameworkPerformaceExpectationToJobRoleDto, SkillsFrameworkPerformaceExpectationToJobRole>();
        CreateMap<SkillsFrameworkPerformaceExpectationToJobRole, GetSkillsFrameworkPerformaceExpectationToJobRoleDto>();
    }
}
