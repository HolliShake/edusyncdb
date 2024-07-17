
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ISkillsFrameworkTrackSpecializationService:IGenericService<SkillsFrameworkTrackSpecialization>
{
    public Task<ICollection<SkillsFrameworkTrackSpecialization>> GetSkillsFrameworkTrackSpecializationsBySectorDisciplineId(int sectorDisciplineId);
}
