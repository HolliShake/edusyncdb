using APPLICATION.Dto.ScholarshipApplication;
using DOMAIN.Model;

namespace APPLICATION.IService.ScholarshipData;

public interface IScholarshipApplicationService:IGenericService<ScholarshipApplication, GetScholarshipApplicationDto>
{
}
