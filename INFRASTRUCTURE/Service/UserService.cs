using APPLICATION.Dto.AccessList;
using APPLICATION.Dto.AccessListAction;
using APPLICATION.Dto.User;
using APPLICATION.Dto.UserAccess;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;

public class UserService:GenericService<User, GetUserDto>, IUserService
{
    public UserService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetUserDto>> GetLimitedUserWithAccess(int limit)
    {
        return await _dbModel
            .Include(x => x.AccessList)
            .ThenInclude(x => x.AccessList)
            .ThenInclude(x => x.AccessListActions)
            .Take(limit)
            .Select(x => new GetUserDto 
            {
                Id = x.Id,
                Address = x.Address,
                BirthDate = x.BirthDate,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Role = x.Role,
                UserName = x.UserName,
                AccessList = (ICollection<GetUserAccessDto>) x.AccessList.Select(y => new GetUserAccessDto
                {
                    Id = y.Id,
                    UserId=y.UserId,
                    AccessListId = y.AccessListId,
                    AccessList = new GetAccessListDto { Id = y.AccessListId, Subject = y.AccessList.Subject },
                    AccessListActionId = y.AccessListActionId,
                    AccessListAction = new GetAccessListActionDto { Id = y.AccessListActionId, Action = y.AccessListAction.Action },
                })
            })
            .ToListAsync();
    }
}