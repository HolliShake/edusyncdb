using APPLICATION.Dto.EnrollmentRole;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EnrollmentRoleService:GenericService<EnrollmentRole, GetEnrollmentRoleDto>, IEnrollmentRoleService
{
    public EnrollmentRoleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
