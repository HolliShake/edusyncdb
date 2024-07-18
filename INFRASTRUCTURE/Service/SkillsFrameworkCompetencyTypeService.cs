using APPLICATION.Dto.SkillsFrameworkCompetencyType;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCompetencyTypeService:GenericService<SkillsFrameworkCompetencyType, GetSkillsFrameworkCompetencyTypeDto>, ISkillsFrameworkCompetencyTypeService
{
    public SkillsFrameworkCompetencyTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
