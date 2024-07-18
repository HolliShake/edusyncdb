using APPLICATION.Dto.SkillsFrameworkCompetencyCategory;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class SkillsFrameworkCompetencyCategoryService:GenericService<SkillsFrameworkCompetencyCategory, GetSkillsFrameworkCompetencyCategoryDto>, ISkillsFrameworkCompetencyCategoryService
{
    public SkillsFrameworkCompetencyCategoryService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
