using APPLICATION.Dto.EducationalQualityAssuranceLearningObjective;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class EducationalQualityAssuranceLearningObjectiveService:GenericService<EducationalQualityAssuranceLearningObjective, GetEducationalQualityAssuranceLearningObjectiveDto>, IEducationalQualityAssuranceLearningObjectiveService
{
    public EducationalQualityAssuranceLearningObjectiveService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetEducationalQualityAssuranceLearningObjectiveDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetEducationalQualityAssuranceLearningObjectiveDto>>(await _dbModel
            .Include(eqalo => eqalo.EqaCourseObjective)
            .ToListAsync());
    }

    public async new Task<GetEducationalQualityAssuranceLearningObjectiveDto?> GetAsync(int id)
    {
        return _mapper.Map<GetEducationalQualityAssuranceLearningObjectiveDto?>(await _dbModel
            .Include(eqalo => eqalo.EqaCourseObjective)
            .Where(eqalo => eqalo.Id == id).FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(EducationalQualityAssuranceLearningObjective newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.EqaCourseObjective = await _dbContext.EducationalQualityAssuranceCourseObjectives.FindAsync(newItem.EqaCourseObjectiveId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(EducationalQualityAssuranceLearningObjective updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.EqaCourseObjective = await _dbContext.EducationalQualityAssuranceCourseObjectives.FindAsync(updatedItem.EqaCourseObjectiveId);
        }
        return result;
    }
}
