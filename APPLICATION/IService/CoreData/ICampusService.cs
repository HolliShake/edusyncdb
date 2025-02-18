
using APPLICATION.Dto.Campus;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface ICampusService:IGenericService<Campus, GetCampusDto>
{
    public Task<ICollection<GetCampusDto>> GetCampusByAgendyId(int agencyId);
}
