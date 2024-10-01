
using APPLICATION.Dto.GeneratedSections;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IGeneratedSectionsService:IGenericService<GeneratedSections, GetGeneratedSectionsDto>
{
    public Task<ICollection<GetGeneratedSectionsDto>> GetGeneratedSectionByCurriculumCycleIdAndYearLevel(int curriculumId, int cycleId, int yearLevel);
    public Task<object?> GenerateSections(int numberOfSection, GenerateSectionGroupDto item);
}
