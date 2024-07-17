using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICurriculumService:IGenericService<Curriculum>
{
    public Task<ICollection<Curriculum>> GetCurriculumByAcademicProgramId(int academicProgramId);
}
