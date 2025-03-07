
using APPLICATION.Dto.CurriculumDetail;
using DOMAIN.Model;

namespace APPLICATION.IService.CurriculumData;

public interface ICurriculumDetailService:IGenericService<CurriculumDetail, GetCurriculumDetailDto>
{
    public Task<object> GetInfoByCurriculumId(int curriculumId);
    public Task<ICollection<GetCurriculumDetailDto>> GetCurriculumDetailsByCourseId(int courseId);
    public Task<object?> CreateCurriculumDetailGroupedByCourse(CurriculumDetailGroup curriculumDetailGroup);
}
