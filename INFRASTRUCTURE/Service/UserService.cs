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
                .ThenInclude(x => x.AccessGroup)
                .Include(x => x.AccessList)
                .ThenInclude(x => x.AccessListAction)
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
                UserAccessGroupedBy = (ICollection<UserAccessGroupedBy>) x.AccessList.Select(y => new UserAccessGroupedBy
                {
                    AccessGroup = new APPLICATION.Dto.AccessGroup.GetAccessGroupDto
                    {
                        Id = y.AccessList.AccessGroup.Id,
                        AccessGroupName = y.AccessList.AccessGroup.AccessGroupName,
                    },
                    UserAccesses = _mapper.Map<ICollection<GetUserAccessDto>>(x.AccessList.Select(z => new GetUserAccessDto
                    {
                        Id = z.Id,
                        UserId = z.UserId,
                        AccessListId = z.AccessListId,
                        AccessList = new GetAccessListDto
                        {
                            Id = z.AccessList.Id,
                            Subject = z.AccessList.Subject,
                        },
                        AccessListActionId = z.AccessListActionId,
                        AccessListAction = new GetAccessListActionDto
                        {
                            Id = z.AccessListAction.Id,
                            Action = z.AccessListAction.Action,
                        }
                    }))
                })
            })
            .ToListAsync();
    }
}