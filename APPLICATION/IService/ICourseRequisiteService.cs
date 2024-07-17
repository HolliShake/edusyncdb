using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICourseRequisiteService:IGenericService<CourseRequisite>
{
    public Task<ICollection<CourseRequisite>> GetCourseRequisitesByCourseIdAndType(int courseId, int type);
}
