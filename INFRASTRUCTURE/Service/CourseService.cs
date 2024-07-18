using APPLICATION.Dto.Course;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CourseService:GenericService<Course, GetCourseDto>, ICourseService
{
    public CourseService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetCourseDto>> GetAllWithRequisiteAsync()
    {
        return _mapper.Map<ICollection<GetCourseDto>>(await _dbModel
            .Include(c => c.CourseRequisites)
            .ThenInclude(cr => cr.RequisiteCourse)
            .ToListAsync());
    }

    public async Task<GetCourseDto?> GetWithRequisiteAsync(int id)
    {
        return _mapper.Map<GetCourseDto?>(await _dbModel
            .Include(c => c.CourseRequisites)
            .ThenInclude(cr => cr.RequisiteCourse)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync());
    }

    public async Task<ICollection<GetCourseDto>> GetCourseByEducationalQualityAssuranceType(int educationalQualityAssuranceTypeId, bool includeRequisites)
    {
        if (includeRequisites)
        {
            return _mapper.Map<ICollection<GetCourseDto>>(await _dbModel
                .Include(c => c.CourseRequisites)
                .ThenInclude(cr => cr.RequisiteCourse)
                .Where(c => c.EducationalQualityAssuranceTypeId == educationalQualityAssuranceTypeId)
                .ToListAsync());
        }
        else
        {
            return _mapper.Map<ICollection<GetCourseDto>>(await _dbModel
                .Where(c => c.EducationalQualityAssuranceTypeId == educationalQualityAssuranceTypeId)
                .ToListAsync());
        }
    }

    public async Task<ICollection<GetCourseDto>> GetCourseBySkillsFrameworkTrackSpecializationId(int trackSpecializationId, bool includeRequisites)
    {
        if (includeRequisites)
        {
            return _mapper.Map<ICollection<GetCourseDto>>(await _dbModel
                .Include(c => c.CourseRequisites)
                .ThenInclude(cr => cr.RequisiteCourse)
                .Where(c => c.SfTrackSpecializationId == trackSpecializationId)
                .ToListAsync());
        }
        else
        {
            return _mapper.Map<ICollection<GetCourseDto>>(await _dbModel.Where(c => c.SfTrackSpecializationId == trackSpecializationId).ToListAsync());
        }
    }
}
