
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CourseRequisiteService:GenericService<CourseRequisite>, ICourseRequisiteService
{
    public CourseRequisiteService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<CourseRequisite>> GetCourseRequisitesByCourseIdAndType(int courseId, int type)
    {
        return await _dbModel
            .Include(cr => cr.RequisiteCourse)
            .Where(cr => cr.CourseId == courseId)
            .Where(cr => (int) cr.Type == type)
            .ToListAsync();
    }
}
