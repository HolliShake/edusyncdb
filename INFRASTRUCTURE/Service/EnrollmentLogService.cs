using APPLICATION.Dto.EnrollmentLog;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EnrollmentLogService:GenericService<EnrollmentLog, GetEnrollmentLogDto>, IEnrollmentLogService
{
    public EnrollmentLogService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
