using APPLICATION.Dto.Campus;
using APPLICATION.Dto.CampusRegistrar;
using DOMAIN.Model;

namespace APPLICATION.IService.DesignationData;
public interface ICampusRegistrarService : IGenericService<CampusRegistrar, GetCampusRegistrarDto>
{
    public Task<bool> IsCampusRegistrar(string userId);

    public Task<GetCampusDto> GetCampusByUserId(string userId);
}
