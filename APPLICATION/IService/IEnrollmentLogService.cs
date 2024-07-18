using APPLICATION.Dto.EnrollmentLog;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IEnrollmentLogService:IGenericService<EnrollmentLog, GetEnrollmentLogDto>
{
}
