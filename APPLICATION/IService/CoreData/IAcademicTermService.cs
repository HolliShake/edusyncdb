using APPLICATION.Dto.AcademicTerm;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface IAcademicTermService:IGenericService<AcademicTerm, GetAcademicTermDto>
{
}
