
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICourseService:IGenericService<Course>
{
    public Task<ICollection<Course>> GetAllWithRequisiteAsync();
    public Task<Course?> GetWithRequisiteAsync(int id);
    public Task<ICollection<Course>> GetCourseByEducationalQualityAssuranceType(int educationalQualityAssuranceTypeId, bool includeRequisites);
    public Task<ICollection<Course>> GetCourseBySkillsFrameworkTrackSpecializationId(int trackSpecializationId, bool includeRequisites);
}
