using AutoMapper;
using APPLICATION.Dto.EnrollmentRole;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EnrollmentRoleMapper : Profile
{
    public EnrollmentRoleMapper()
    {
        CreateMap<EnrollmentRoleDto, EnrollmentRole>();
        CreateMap<EnrollmentRole, GetEnrollmentRoleDto>();
    }
}
