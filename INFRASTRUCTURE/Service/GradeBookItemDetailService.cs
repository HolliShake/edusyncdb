using APPLICATION.Dto.GradeBookItemDetail;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeBookItemDetailService:GenericService<GradeBookItemDetail, GetGradeBookItemDetailDto>, IGradeBookItemDetailService
{
    public GradeBookItemDetailService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<bool> CreateAsync(GradeBookItemDetail newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.EqaAssessmentType = _dbContext.EducationalQualityAssuranceAssessmentTypes.Find(newItem.EqaAssessmentTypeId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(GradeBookItemDetail updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.EqaAssessmentType = _dbContext.EducationalQualityAssuranceAssessmentTypes.Find(updatedItem.EqaAssessmentTypeId);
        }
        return result;
    }
}
