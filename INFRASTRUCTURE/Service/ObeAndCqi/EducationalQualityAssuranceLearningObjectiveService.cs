using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.EducationalQualityAssuranceLearningObjective;
using APPLICATION.IService.ObeAndCqi;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.ObeAndCqi;

public class EducationalQualityAssuranceLearningObjectiveService:GenericService<EducationalQualityAssuranceLearningObjective, GetEducationalQualityAssuranceLearningObjectiveDto>, IEducationalQualityAssuranceLearningObjectiveService
{
    public EducationalQualityAssuranceLearningObjectiveService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetEducationalQualityAssuranceLearningObjectiveDto>> GetAllAsync()
    {
        var eqaLearningObjectives = await _dbModel
            .Include(eqalo => eqalo.EqaCourseObjective)
            .ToListAsync();
        return _mapper.Map<ICollection<GetEducationalQualityAssuranceLearningObjectiveDto>>(eqaLearningObjectives);
    }

    public async new Task<EducationalQualityAssuranceLearningObjective?> GetAsync(int id)
    {
        var eqaLearningObjective = await _dbModel
        .Include(eqalo => eqalo.EqaCourseObjective)
        .Where(eqalo => eqalo.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return eqaLearningObjective;
    }

    public async new Task<GetEducationalQualityAssuranceLearningObjectiveDto?> CreateAsync(EducationalQualityAssuranceLearningObjective newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.EqaCourseObjective = _dbContext.EducationalQualityAssuranceCourseObjectives.Find(newItem.EqaCourseObjectiveId);
            return _mapper.Map<GetEducationalQualityAssuranceLearningObjectiveDto>(newItem);
        }
        return null;
    }

    public async new Task<GetEducationalQualityAssuranceLearningObjectiveDto?> UpdateAsync(EducationalQualityAssuranceLearningObjective updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.EqaCourseObjective = _dbContext.EducationalQualityAssuranceCourseObjectives.Find(updatedItem.EqaCourseObjectiveId);
            return _mapper.Map<GetEducationalQualityAssuranceLearningObjectiveDto>(updatedItem);
        }
        return null;
    }
}
