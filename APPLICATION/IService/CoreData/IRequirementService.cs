using APPLICATION.Dto.Requirement;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface IRequirementService:IGenericService<Requirement, GetRequirementDto>
{
    public Task<ICollection<GetRequirementDto>> GetActiveRequirement();
}
