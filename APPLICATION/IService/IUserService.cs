using APPLICATION.Dto.User;
using DOMAIN.Model;

namespace APPLICATION.IService;
public interface IUserService:IGenericService<User, GetUserDto>
{
    public Task<ICollection<GetUserDto>> GetLimitedUserWithAccess(int limit);
}