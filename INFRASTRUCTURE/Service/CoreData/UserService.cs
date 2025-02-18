using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.User;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class UserService:GenericService<User, GetUserDto>, IUserService
{
    public UserService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<User?> GetUserId(string userId)
    {
        return await _dbModel
            .Where(user => user.Id == userId)
            .SingleOrDefaultAsync();
    }

    public async Task<ICollection<GetUserOnlyDto>> SearchUserByName(string search)
    {
        return await _dbModel
            .Where(x => (x.LastName + ", " + x.FirstName).Contains(search))
            .Select(x => _mapper.Map<GetUserOnlyDto>(x))
            .ToListAsync();
    }

    public async Task<ICollection<GetUserDto>> GetLimitedUserWithAccess(int limit)
    {
        return [];
    }
}