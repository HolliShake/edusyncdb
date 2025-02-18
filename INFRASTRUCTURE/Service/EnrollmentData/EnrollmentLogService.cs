using AutoMapper;
using APPLICATION.Dto.EnrollmentLog;
using APPLICATION.IService.EnrollmentData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EnrollmentData;

public class EnrollmentLogService:GenericService<EnrollmentLog, GetEnrollmentLogDto>, IEnrollmentLogService
{
    public EnrollmentLogService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
