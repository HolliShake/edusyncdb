using AutoMapper;
using APPLICATION.Dto.EnrollmentRole;
using APPLICATION.IService.EnrollmentData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EnrollmentData;

public class EnrollmentRoleService:GenericService<EnrollmentRole, GetEnrollmentRoleDto>, IEnrollmentRoleService
{
    public EnrollmentRoleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
