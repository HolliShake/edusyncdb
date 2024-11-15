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
        var eqaCourseObjective = await _dbModel
        .Include(eqaco => eqaco.EqaProgramObjective)
        .Where(eqaco => eqaco.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return eqaCourseObjective;
    }

    public async new Task<GetEducationalQualityAssuranceCourseObjectiveDto?> CreateAsync(EducationalQualityAssuranceCourseObjective newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.EqaProgramObjective = _dbContext.EducationalQualityAssuranceProgramObjectives.Find(newItem.EqaProgramObjectiveId);
            return _mapper.Map<GetEducationalQualityAssuranceCourseObjectiveDto>(newItem);
        }
        return null;
    }

    public async new Task<GetEducationalQualityAssuranceCourseObjectiveDto?> UpdateAsync(EducationalQualityAssuranceCourseObjective updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.EqaProgramObjective = _dbContext.EducationalQualityAssuranceProgramObjectives.Find(updatedItem.EqaProgramObjectiveId);
            return _mapper.Map<GetEducationalQualityAssuranceCourseObjectiveDto>(updatedItem);
        }
        return null;
    }
}
