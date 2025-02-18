
using APPLICATION.Dto.Course;
using DOMAIN.Model;

namespace APPLICATION.IService.CourseCatalogData;

public interface ICourseService:IGenericService<Course, GetCourseDto>
{
    public Task<ICollection<GetCourseDto>> GetAllWithRequisiteAsync();
    public Task<GetCourseDto?> GetWithRequisiteAsync(int id);
    public Task<ICollection<GetCourseDto>> GetCourseByEducationalQualityAssuranceType(int educationalQualityAssuranceTypeId, bool includeRequisites);
    public Task<ICollection<GetCourseDto>> GetCourseBySkillsFrameworkTrackSpecializationId(int trackSpecializationId, bool includeRequisites);
    public Task<object> GetAllCourseGroupByTrackSpecialization();
}
