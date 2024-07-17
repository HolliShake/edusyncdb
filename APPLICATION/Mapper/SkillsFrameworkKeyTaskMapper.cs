using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkKeyTask;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class SkillsFrameworkKeyTaskMapper : Profile
{
    public SkillsFrameworkKeyTaskMapper()
    {
        CreateMap<SkillsFrameworkKeyTaskDto, SkillsFrameworkKeyTask>();
        CreateMap<SkillsFrameworkKeyTask, GetSkillsFrameworkKeyTaskDto>();
    }
}
