using APPLICATION.Dto.SkillsFrameworkCompetency;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCompetencyService:GenericService<SkillsFrameworkCompetency, GetSkillsFrameworkCompetencyDto>, ISkillsFrameworkCompetencyService
{
    public SkillsFrameworkCompetencyService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
