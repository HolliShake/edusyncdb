
using APPLICATION.Dto.CurriculumDetail;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICurriculumDetailService:IGenericService<CurriculumDetail, GetCurriculumDetailDto>
{
    public Task<ICollection<GetCurriculumDetailDto>> GetCurriculumDetailsByCourseId(int courseId);
}