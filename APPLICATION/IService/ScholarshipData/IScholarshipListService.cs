using APPLICATION.Dto.ScholarshipList;
using DOMAIN.Model;

namespace APPLICATION.IService.ScholarshipData;

public interface IScholarshipListService:IGenericService<ScholarshipList, GetScholarshipListDto>
{
}
