using APPLICATION.Dto.EducationalQualityAssuranceCourseObjective;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceCourseObjectiveService:GenericService<EducationalQualityAssuranceCourseObjective, GetEducationalQualityAssuranceCourseObjectiveDto>, IEducationalQualityAssuranceCourseObjectiveService
{
    public EducationalQualityAssuranceCourseObjectiveService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetEducationalQualityAssuranceCourseObjectiveDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetEducationalQualityAssuranceCourseObjectiveDto>>(await _dbModel
            .Include(eqaco => eqaco.EqaProgramObjective)
            .ToListAsync());
    }

    public async new Task<EducationalQualityAssuranceCourseObjective?> GetAsync(int id)
    {
        return _mapper.Map<EducationalQualityAssuranceCourseObjective?>(await _dbModel
            .Include(eqaco => eqaco.EqaProgramObjective)
            .Where(eqaco => eqaco.Id == id).FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(EducationalQualityAssuranceCourseObjective newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.EqaProgramObjective = await _dbContext.EducationalQualityAssuranceProgramObjectives.FindAsync(newItem.EqaProgramObjectiveId);
        }
        return result;
    }

    public async Task<bool> UpdateSync(EducationalQualityAssuranceCourseObjective updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.EqaProgramObjective = await _dbContext.EducationalQualityAssuranceProgramObjectives.FindAsync(updatedItem.EqaProgramObjectiveId);
        }
        return result;
    }
}
