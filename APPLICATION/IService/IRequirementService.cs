using APPLICATION.Dto.Requirement;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IRequirementService:IGenericService<Requirement, GetRequirementDto>
{
    public Task<ICollection<GetRequirementDto>> GetActiveRequirement();
}
