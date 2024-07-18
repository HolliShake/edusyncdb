
using APPLICATION.Dto.CurriculumDetail;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CurriculumDetailService:GenericService<CurriculumDetail, GetCurriculumDetailDto>, ICurriculumDetailService
{
    public CurriculumDetailService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetCurriculumDetailDto>> GetCurriculumDetailsByCourseId(int courseId)
    {
        return _mapper.Map<ICollection<GetCurriculumDetailDto>>(await _dbModel
            .Include(cd => cd.Curriculum)
            .Where(cd => cd.CourseId == courseId)
            .ToListAsync());
    }
}
