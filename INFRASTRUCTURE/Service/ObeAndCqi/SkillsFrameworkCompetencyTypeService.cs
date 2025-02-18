using AutoMapper;
using APPLICATION.Dto.SkillsFrameworkCompetencyType;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class SkillsFrameworkCompetencyTypeService:GenericService<SkillsFrameworkCompetencyType, GetSkillsFrameworkCompetencyTypeDto>, ISkillsFrameworkCompetencyTypeService
{
    public SkillsFrameworkCompetencyTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
