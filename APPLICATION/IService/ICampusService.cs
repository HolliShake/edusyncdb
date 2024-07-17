
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface ICampusService:IGenericService<Campus>
{
    public Task<ICollection<Campus>> GetCampusByAgendyId(int agencyId);
}
