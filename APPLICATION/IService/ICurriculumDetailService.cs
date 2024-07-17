
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICurriculumDetailService:IGenericService<CurriculumDetail>
{
    public Task<ICollection<CurriculumDetail>> GetCurriculumDetailsByCourseId(int courseId);
}
