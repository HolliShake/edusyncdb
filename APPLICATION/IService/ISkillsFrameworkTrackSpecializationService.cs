using APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ISkillsFrameworkTrackSpecializationService:IGenericService<SkillsFrameworkTrackSpecialization, GetSkillsFrameworkTrackSpecializationDto>
{
    public Task<ICollection<GetSkillsFrameworkTrackSpecializationDto>> GetSkillsFrameworkTrackSpecializationsBySectorDisciplineId(int sectorDisciplineId);
}