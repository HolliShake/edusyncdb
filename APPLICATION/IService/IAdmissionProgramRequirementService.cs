
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IAdmissionProgramRequirementService:IGenericService<AdmissionProgramRequirement>
{
    public Task<ICollection<AdmissionProgramRequirement>> GetEnabledAdmissionProgramRequirements();
}
