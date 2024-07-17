
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CurriculumService:GenericService<Curriculum>, ICurriculumService
{
    public CurriculumService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<Curriculum>> GetCurriculumByAcademicProgramId(int academicProgramId)
    {
        return await _dbModel.Where(c => c.AcademicProgramId == academicProgramId).ToListAsync();
    }
}
