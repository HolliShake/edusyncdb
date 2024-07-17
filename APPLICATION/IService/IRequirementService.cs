using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IRequirementService:IGenericService<Requirement>
{
    public Task<ICollection<Requirement>> GetActiveRequirement();
}
