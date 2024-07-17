
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CourseService:GenericService<Course>, ICourseService
{
    public CourseService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<Course>> GetAllWithRequisiteAsync()
    {
        return await _dbModel
            .Include(c => c.CourseRequisites)
            .ThenInclude(cr => cr.RequisiteCourse)
            .ToListAsync();
    }

    public async Task<Course?> GetWithRequisiteAsync(int id)
    {
        return await _dbModel
            .Include(c => c.CourseRequisites)
            .ThenInclude(cr => cr.RequisiteCourse)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<ICollection<Course>> GetCourseByEducationalQualityAssuranceType(int educationalQualityAssuranceTypeId, bool includeRequisites)
    {
        if (includeRequisites)
        {
            return await _dbModel
                .Include(c => c.CourseRequisites)
                .ThenInclude(cr => cr.RequisiteCourse)
                .Where(c => c.EducationalQualityAssuranceTypeId == educationalQualityAssuranceTypeId)
                .ToListAsync();
        }
        else
        {
            return await _dbModel
                .Where(c => c.EducationalQualityAssuranceTypeId == educationalQualityAssuranceTypeId)
                .ToListAsync();
        }
    }

    public async Task<ICollection<Course>> GetCourseBySkillsFrameworkTrackSpecializationId(int trackSpecializationId, bool includeRequisites)
    {
        if (includeRequisites)
        {
            return await _dbModel
                .Include(c => c.CourseRequisites)
                .ThenInclude(cr => cr.RequisiteCourse)
                .Where(c => c.SfTrackSpecializationId == trackSpecializationId)
                .ToListAsync();
        }
        else
        {
            return await _dbModel.Where(c => c.SfTrackSpecializationId == trackSpecializationId).ToListAsync();
        }
    }
}
