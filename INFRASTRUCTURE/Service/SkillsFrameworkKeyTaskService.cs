using APPLICATION.Dto.SkillsFrameworkKeyTask;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkKeyTaskService:GenericService<SkillsFrameworkKeyTask, GetSkillsFrameworkKeyTaskDto>, ISkillsFrameworkKeyTaskService
{
    public SkillsFrameworkKeyTaskService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}