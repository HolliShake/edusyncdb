using APPLICATION.Dto.Curriculum;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICurriculumService:IGenericService<Curriculum, GetCurriculumDto>
{
    public Task<ICollection<GetCurriculumDto>> GetCurriculumByAcademicProgramId(int academicProgramId);
}
