
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CurriculumDetailService:GenericService<CurriculumDetail>, ICurriculumDetailService
{
    public CurriculumDetailService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<CurriculumDetail>> GetCurriculumDetailsByCourseId(int courseId)
    {
        return await _dbModel
            .Include(cd => cd.Curriculum)
            .Where(cd => cd.CourseId == courseId)
            .ToListAsync();
    }
}
