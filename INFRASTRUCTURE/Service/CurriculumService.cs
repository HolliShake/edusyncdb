using APPLICATION.Dto.Curriculum;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CurriculumService:GenericService<Curriculum, GetCurriculumDto>, ICurriculumService
{
    public CurriculumService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetCurriculumDto>> GetCurriculumByAcademicProgramId(int academicProgramId)
    {
        return _mapper.Map<ICollection<GetCurriculumDto>>(await _dbModel.Where(c => c.AcademicProgramId == academicProgramId).ToListAsync());
    }
}
