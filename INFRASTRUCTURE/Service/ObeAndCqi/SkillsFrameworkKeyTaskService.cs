using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkKeyTask;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkKeyTaskService:GenericService<SkillsFrameworkKeyTask, GetSkillsFrameworkKeyTaskDto>, ISkillsFrameworkKeyTaskService
{
    public SkillsFrameworkKeyTaskService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
