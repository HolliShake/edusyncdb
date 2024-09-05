using APPLICATION.Dto.UserCampusDetails;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class UserCampusDetailsService:GenericService<UserCampusDetails, GetUserCampusDetailsDto>, IUserCampusDetailsService
{
    public UserCampusDetailsService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
