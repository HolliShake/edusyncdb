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
        var academicPrograms = await _dbModel
        .Include(ap => ap.College)
        .OrderBy(ap => ap.ProgramName)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAcademicProgramDto>>(academicPrograms);
    }

    public async Task<ICollection<GetAcademicProgramDto>> GetAcademicProgramByCampusId(int campusId)
    {
        var academicPrograms = await _dbModel
        .Include(ap => ap.College)
        .Where(ap => ap.College.CampusId == campusId)
        .OrderBy(ap => ap.ProgramName)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAcademicProgramDto>>(academicPrograms);
    }

    public async new Task<AcademicProgram?> GetAsync(int id)
    {
        var academicProgram = await _dbModel
        .Include(ap => ap.College)
        .Where(ap => ap.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return academicProgram;
    }

    public async new Task<GetAcademicProgramDto?> CreateAsync(AcademicProgram newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.College = await _dbContext.Colleges.FindAsync(newItem.CollegeId);
            return _mapper.Map<GetAcademicProgramDto>(newItem);
        }
        return null;
    }

    public async new Task<GetAcademicProgramDto?> UpdateAsync(AcademicProgram updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.College = await _dbContext.Colleges.FindAsync(updatedItem.CollegeId);
            return _mapper.Map<GetAcademicProgramDto>(updatedItem);
        }
        return null;
    }
}
