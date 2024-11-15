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

    public async new Task<GetGradeBookItemDetailDto?> CreateAsync(GradeBookItemDetail newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.EqaAssessmentType = _dbContext.EducationalQualityAssuranceAssessmentTypes.Find(newItem.EqaAssessmentTypeId);
            return _mapper.Map<GetGradeBookItemDetailDto>(newItem);
        }
        return null;
    }

    public async new Task<GetGradeBookItemDetailDto?> UpdateAsync(GradeBookItemDetail updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.EqaAssessmentType = _dbContext.EducationalQualityAssuranceAssessmentTypes.Find(updatedItem.EqaAssessmentTypeId);
            return _mapper.Map<GetGradeBookItemDetailDto>(updatedItem);
        }
        return null;
    }
}
