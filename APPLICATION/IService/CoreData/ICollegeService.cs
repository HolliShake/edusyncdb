using APPLICATION.Dto.College;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface ICollegeService : IGenericService<College, GetCollegeDto>
{ 
    public Task<ICollection<GetCollegeDto>> GetCollegesByCampusId(int campusId); 
}
