using APPLICATION.Dto.EnrollmentLog;
using DOMAIN.Model;

namespace APPLICATION.IService.EnrollmentData;

public interface IEnrollmentLogService:IGenericService<EnrollmentLog, GetEnrollmentLogDto>
{
}
