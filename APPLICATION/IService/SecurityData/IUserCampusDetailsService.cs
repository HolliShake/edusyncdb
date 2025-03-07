
using DOMAIN.Model;
using APPLICATION.Dto.UserCampusDetails;
using APPLICATION.Dto.Campus;

namespace APPLICATION.IService.SecurityData;

public interface IUserCampusDetailsService:IGenericService<UserCampusDetails, GetUserCampusDetailsDto>
{
    public Task<ICollection<GetCampusDto>> GetAllCampusByUserId(string userId);
}
