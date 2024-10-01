
using APPLICATION.Dto.AdmissionProgramRequirement;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAdmissionProgramRequirementService:IGenericService<AdmissionProgramRequirement, GetAdmissionProgramRequirementDto>
{
    public Task<ICollection<GetAdmissionProgramRequirementDto>> GetEnabledAdmissionProgramRequirements();
    public Task<object> GetAllGroupedByRequirementAsync();
    public Task<object?> CreateMultipleAdmissionProgramRequirement(AdmissionProgramRequirementMultipleDto item);
}
