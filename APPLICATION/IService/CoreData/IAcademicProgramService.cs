using APPLICATION.Dto.AcademicProgram;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface IAcademicProgramService:IGenericService<AcademicProgram, GetAcademicProgramDto>
{
    public Task<ICollection<GetAcademicProgramDto>> GetAcademicProgramByCampusId(int campusId);
    public Task<ICollection<GetAcademicProgramDto>> GetAcademicProgramByCollegeId(int collegeId);
}
