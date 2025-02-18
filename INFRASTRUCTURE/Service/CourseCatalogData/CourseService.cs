using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.Course;
using APPLICATION.IService.CourseCatalogData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CourseCatalogData;

public class CourseService:GenericService<Course, GetCourseDto>, ICourseService
{
    public CourseService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public new async Task<ICollection<GetCourseDto>> GetAllAsync()
    {
        var result = await _dbModel
            .Include(c => c.EducationalQualityAssuranceType)
            .Include(c => c.SfTrackSpecialization)
            .Include(c => c.CourseRequisites)
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<ICollection<GetCourseDto>>(result);
    }

    public async new Task<GetCourseDto?> CreateAsync(Course newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.SfTrackSpecialization = _dbContext.SkillsFrameworkTrackSpecializations.Find(newItem.SfTrackSpecializationId);
            newItem.EducationalQualityAssuranceType = _dbContext.EducationalQualityAssuranceTypes.Find(newItem.EducationalQualityAssuranceTypeId);
            return _mapper.Map<GetCourseDto>(newItem);
        }
        return null;
    }

    public async new Task<GetCourseDto?> UpdateAsync(Course updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.SfTrackSpecialization = _dbContext.SkillsFrameworkTrackSpecializations.Find(updatedItem.SfTrackSpecializationId);
            updatedItem.EducationalQualityAssuranceType = _dbContext.EducationalQualityAssuranceTypes.Find(updatedItem.EducationalQualityAssuranceTypeId);
            return _mapper.Map<GetCourseDto>(updatedItem);
        }
        return null;
    }

    public async Task<ICollection<GetCourseDto>> GetAllWithRequisiteAsync()
    {
        var courses = await _dbModel
        .Include(c => c.EducationalQualityAssuranceType)
        .Include(c => c.SfTrackSpecialization)
        .Include(c => c.CourseRequisites)
            .ThenInclude(cr => cr.RequisiteCourse)
        .ToListAsync();
        return _mapper.Map<ICollection<GetCourseDto>>(courses);
    }

    public async Task<GetCourseDto?> GetWithRequisiteAsync(int id)
    {
        var course = await _dbModel
        .Include(c => c.EducationalQualityAssuranceType)
        .Include(c => c.SfTrackSpecialization)
        .Include(c => c.CourseRequisites)
            .ThenInclude(cr => cr.RequisiteCourse)
        .FirstOrDefaultAsync(c => c.Id == id);
        return _mapper.Map<GetCourseDto?>(course);
    }

    public async Task<ICollection<GetCourseDto>> GetCourseByEducationalQualityAssuranceType(int educationalQualityAssuranceTypeId, bool includeRequisites)
    {
        var query = _dbModel
            .Include(c => c.EducationalQualityAssuranceType)
            .Include(c => c.SfTrackSpecialization)
            .Where(c => c.EducationalQualityAssuranceTypeId == educationalQualityAssuranceTypeId);
        if (includeRequisites)
        {
            query = query
                .Include(c => c.CourseRequisites)
                .ThenInclude(cr => cr.RequisiteCourse);
        }
        var courses = await query.ToListAsync();
        return _mapper.Map<ICollection<GetCourseDto>>(courses);
    }

    public async Task<ICollection<GetCourseDto>> GetCourseBySkillsFrameworkTrackSpecializationId(int trackSpecializationId, bool includeRequisites)
    {
        var query = _dbModel
            .Include(c => c.EducationalQualityAssuranceType)
            .Include(c => c.SfTrackSpecialization)
            .Where(c => c.SfTrackSpecializationId == trackSpecializationId);

        if (includeRequisites)
        {
            query = query
                .Include(c => c.CourseRequisites)
                .ThenInclude(cr => cr.RequisiteCourse);
        }

        var courses = await query.ToListAsync();
        return _mapper.Map<ICollection<GetCourseDto>>(courses);
    }

    public async Task<object> GetAllCourseGroupByTrackSpecialization()
    {
        var result = await _dbModel
            .Include(c => c.SfTrackSpecialization)
            .Include(c => c.CourseRequisites)
                .ThenInclude(cr => cr.RequisiteCourse)
            .AsNoTracking()
            .ToListAsync();

        var distinctOverride = result
            .Select(c => c.SfTrackSpecializationId)
            .Distinct()
            .Select(c => result.Where(r => r.SfTrackSpecializationId == c).Select(r => r.SfTrackSpecialization).FirstOrDefault());

        return distinctOverride.Select(c => new
        {
            Id = c.Id,
            Specialization = c.Specialization,
            SectorDisciplineId = c.SectorDisciplineId,
            SectorDiscipline = c.SectorDiscipline,
            Courses = result.Where(r => r.SfTrackSpecializationId == c.Id).Select(r => new
            {
                Id = r.Id,
                CourseCode = r.CourseCode,
                CourseTitle = r.CourseTitle,
                CourseDescription = r.CourseDescription,
                CreditUnits = r.CreditUnits,
                LaboratoryUnits = r.LaboratoryUnits,
                LectureUnits = r.LectureUnits,
                WithLaboratory = r.WithLaboratory,
                EducationalQualityAssuranceTypeId = r.EducationalQualityAssuranceTypeId,
                EducationalQualityAssuranceType = r.EducationalQualityAssuranceType,
                SfTrackSpecializationId = r.SfTrackSpecializationId,
                SfTrackSpecialization = r.SfTrackSpecialization,
                CourseRequisites = r.CourseRequisites.Select(cr => new
                {
                    Id = cr.Id,
                    CourseId = cr.CourseId,
                    RequisiteCourseId = cr.RequisiteCourseId,
                    RequisiteCourse = cr.RequisiteCourse,
                    Type = cr.Type,
                    TypeName = cr.GetType().Name,
                })
            })
        }).ToList();
    }
}
