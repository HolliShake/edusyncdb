
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICollegeService:IGenericService<College>
{
    public Task<ICollection<College>> GetCollegesByCampusId(int campusId);
}
