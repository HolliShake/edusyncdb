using APPLICATION.Dto.AcademicProgram;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AcademicProgramService:GenericService<AcademicProgram, GetAcademicProgramDto>, IAcademicProgramService
{
    public AcademicProgramService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetAcademicProgramDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetAcademicProgramDto>>(await _dbModel.Include(ap => ap.College).ToListAsync());
    }

    public async new Task<GetAcademicProgramDto?> GetAsync(int id)
    {
        return _mapper.Map<GetAcademicProgramDto?>(await _dbModel.Include(ap => ap.College).Where(ap => ap.Id == id).FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(AcademicProgram newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.College = await _dbContext.Colleges.FindAsync(newItem.CollegeId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(AcademicProgram updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.College = await _dbContext.Colleges.FindAsync(updatedItem.CollegeId);
        }
        return result;
    }
}
