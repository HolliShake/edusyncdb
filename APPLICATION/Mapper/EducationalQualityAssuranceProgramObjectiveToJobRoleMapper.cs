using AutoMapper;
using APPLICATION.Dto.EducationalQualityAssuranceProgramObjectiveToJobRole;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class EducationalQualityAssuranceProgramObjectiveToJobRoleMapper : Profile
{
    public EducationalQualityAssuranceProgramObjectiveToJobRoleMapper()
    {
        CreateMap<EducationalQualityAssuranceProgramObjectiveToJobRoleDto, EducationalQualityAssuranceProgramObjectiveToJobRole>();
        CreateMap<EducationalQualityAssuranceProgramObjectiveToJobRole, GetEducationalQualityAssuranceProgramObjectiveToJobRoleDto>();
    }
}
