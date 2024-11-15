using APPLICATION.Dto.Curriculum;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using INFRASTRUCTURE.ErrorHandler;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CurriculumService:GenericService<Curriculum, GetCurriculumDto>, ICurriculumService
{
    public CurriculumService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetCurriculumDto>> GetAllAsync()
    {
        var curriculum = await _dbModel
        .Include(c => c.AcademicTerm)
        .Include(c => c.ProgramType)
        .Include(c => c.AcademicProgram)
        .Include(c => c.MinGradeToBeCulled)
        .ToListAsync();
        return _mapper.Map<ICollection<GetCurriculumDto>>(curriculum);
    }

    public async new Task<Curriculum?> GetAsync(int id)
    {
        var curriculum = await _dbModel
        .Include(c => c.AcademicTerm)
        .Include(c => c.ProgramType)
        .Include(c => c.AcademicProgram)
        .Include(c => c.MinGradeToBeCulled)
        .Where(c => c.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return curriculum;
    }

    private async Task<bool> CheckForConflict(int academicProgramId, string column, bool activeStatus)
    {
        var items = await _dbModel
            .Where(c => c.AcademicProgramId == academicProgramId)
            .ToListAsync();
        switch (column)
        {
            case "isDefault":
            {
                return items.Any(c => c.IsDefault == activeStatus);
            }
            case "isActive":
            {
                return items.Any(c => c.IsActive == activeStatus);
            }
            default:
            {
                throw new Error400($"Invalid Column {column}");
            }
        }
    }

    private async Task<bool> UnMarkExcept(Curriculum exception)
    {
        // Change current active
        if (exception.IsDefault)
        {
            var currentDefault = _dbModel
                .Where(c => c.Id != exception.Id)
                .Where(c => c.IsDefault)
                .Where(c => c.AcademicProgramId == exception.AcademicProgramId)
                .ToList();
            foreach (var item in currentDefault)
            {
                item.IsDefault = false;
            }
            if (currentDefault.Count > 0)
            {
                _dbModel.UpdateRange(currentDefault);
                return await Save();
            }
        }

        /*
        Allow multiple active curriculum
        if (exception.IsActive)
        {
            var currentActive = _dbModel
                .Where(c => c.Id != exception.Id)
                .Where(c => c.IsActive)
                .Where(c => c.AcademicProgramId == exception.AcademicProgramId)
                .ToList();
            foreach (var item in currentActive)
            {
                item.IsActive = false;
            }
            if (currentActive.Count > 0)
            {
                _dbModel.UpdateRange(currentActive);
                return await Save();
            }
        }
        */
        return true;
    }

    public async new Task<GetCurriculumDto?> CreateAsync(Curriculum newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.AcademicTerm = _dbContext.AcademicTerms.Find(newItem.AcademicTermId);
            newItem.ProgramType = _dbContext.ProgramTypes.Find(newItem.ProgramTypeId);
            newItem.AcademicProgram = _dbContext.AcademicPrograms.Find(newItem.AcademicProgramId);
            newItem.MinGradeToBeCulled = _dbContext.GradeInputs.Find(newItem.MinGradeToBeCulledId);
            var success = await UnMarkExcept(newItem);
            if (!success)
            {
                throw new Error400("Failed to unmark other curriculum.");
            }
            return _mapper.Map<GetCurriculumDto>(newItem);
        }
        return null;
    }

    public async new Task<GetCurriculumDto?> UpdateAsync(Curriculum updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.AcademicTerm = _dbContext.AcademicTerms.Find(updatedItem.AcademicTermId);
            updatedItem.ProgramType = _dbContext.ProgramTypes.Find(updatedItem.ProgramTypeId);
            updatedItem.AcademicProgram = _dbContext.AcademicPrograms.Find(updatedItem.AcademicProgramId);
            updatedItem.MinGradeToBeCulled = _dbContext.GradeInputs.Find(updatedItem.MinGradeToBeCulledId);
            var success = await UnMarkExcept(updatedItem);
            if (!success)
            {
                throw new Error400("Failed to unmark other curriculum.");
            }
            return _mapper.Map<GetCurriculumDto>(updatedItem);
        }
        return null;
    }

    public async Task<ICollection<GetCurriculumDto>> GetCurriculumByAcademicProgramId(int academicProgramId)
    {
        var curriculums = await _dbModel
        .Include(c => c.AcademicTerm)
        .Include(c => c.ProgramType)
        .Include(c => c.AcademicProgram)
        .Include(c => c.MinGradeToBeCulled)
        .Where(c => c.AcademicProgramId == academicProgramId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetCurriculumDto>>(curriculums);
    }
}
