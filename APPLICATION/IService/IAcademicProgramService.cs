using APPLICATION.Dto.AcademicProgram;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAcademicProgramService:IGenericService<AcademicProgram, GetAcademicProgramDto>
{
}