using APPLICATION.Dto.CourseRequisite;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CourseRequisiteService:GenericService<CourseRequisite, GetCourseRequisiteDto>, ICourseRequisiteService
{
    public CourseRequisiteService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<bool> CreateAsync(CourseRequisite newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.Course = await _dbContext.Courses.FindAsync(newItem.CourseId);
            newItem.RequisiteCourse = await _dbContext.Courses.FindAsync(newItem.RequisiteCourseId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(CourseRequisite updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.Course = await _dbContext.Courses.FindAsync(updatedItem.CourseId);
            updatedItem.RequisiteCourse = await _dbContext.Courses.FindAsync(updatedItem.RequisiteCourseId);
        }
        return result;
    }

    public async Task<ICollection<GetCourseRequisiteDto>> GetCourseRequisitesByCourseIdAndType(int courseId, int type)
    {
        return _mapper.Map<ICollection<GetCourseRequisiteDto>>(await _dbModel
            .Include(cr => cr.RequisiteCourse)
            .Where(cr => cr.CourseId == courseId)
            .Where(cr => (int)cr.Type == type)
            .ToListAsync());
    }
}
