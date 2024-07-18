using APPLICATION.Dto.CourseRequisite;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICourseRequisiteService:IGenericService<CourseRequisite, GetCourseRequisiteDto>
{
    public Task<ICollection<GetCourseRequisiteDto>> GetCourseRequisitesByCourseIdAndType(int courseId, int type);
}
