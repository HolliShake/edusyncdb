using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.CourseRequisite;
using APPLICATION.IService.CourseCatalogData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CourseCatalogData;

public class CourseRequisiteService:GenericService<CourseRequisite, GetCourseRequisiteDto>, ICourseRequisiteService
{
    public CourseRequisiteService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<GetCourseRequisiteDto?> CreateAsync(CourseRequisite newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.Course = _dbContext.Courses.Find(newItem.CourseId);
            newItem.RequisiteCourse = _dbContext.Courses.Find(newItem.RequisiteCourseId);
            return _mapper.Map<GetCourseRequisiteDto>(newItem);
        }
        return null;
    }

    public async new Task<GetCourseRequisiteDto?> UpdateAsync(CourseRequisite updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.Course = _dbContext.Courses.Find(updatedItem.CourseId);
            updatedItem.RequisiteCourse = _dbContext.Courses.Find(updatedItem.RequisiteCourseId);
            return _mapper.Map<GetCourseRequisiteDto>(updatedItem);
        }
        return null;
    }

    public async Task<ICollection<GetCourseRequisiteDto>> GetCourseRequisitesByCourseIdAndType(int courseId, int type)
    {
        var courseRequisites = await _dbModel
            .Include(cr => cr.RequisiteCourse)
            .Where(cr => cr.CourseId == courseId)
            .Where(cr => (int)cr.Type == type)
            .ToListAsync();
        return _mapper.Map<ICollection<GetCourseRequisiteDto>>(courseRequisites);
    }
}
