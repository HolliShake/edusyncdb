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

    public async Task<ICollection<GetCourseRequisiteDto>> GetCourseRequisitesByCourseIdAndType(int courseId, int type)
    {
        return _mapper.Map<ICollection<GetCourseRequisiteDto>>(await _dbModel
            .Include(cr => cr.RequisiteCourse)
            .Where(cr => cr.CourseId == courseId)
            .Where(cr => (int)cr.Type == type)
            .ToListAsync());
    }
}
