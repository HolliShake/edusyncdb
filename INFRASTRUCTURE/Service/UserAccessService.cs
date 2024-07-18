
using APPLICATION.Dto.UserAccess;
using APPLICATION.Dto.AccessList;
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace INFRASTRUCTURE.Service;
public class UserAccessService(AppDbContext context, IMapper mapper) : GenericService<UserAccess, GetUserAccessDto>(context, mapper), IUserAccessService
{
    public async Task<ICollection<GetUserAccessDto>> GetUserAccessByUserId(string userId)
    {
        
        return _mapper.Map<ICollection<GetUserAccessDto>>(await _dbModel
            .Include(ua => ua.AccessList)
            .Include(ua => ua.AccessListAction)
            .Where(ua => ua.UserId.Equals(userId))
            .Select(ua => new UserAccess
            {
                Id = ua.Id,
                UserId = ua.UserId,
                AccessListId = ua.AccessListId,
                AccessList = new AccessList
                {
                    Id = ua.AccessList.Id,
                    Subject = ua.AccessList.Subject,
                },
                AccessListActionId = ua.AccessListActionId,
                AccessListAction = new AccessListAction
                {
                    Id = ua.AccessListAction.Id,
                    Action = ua.AccessListAction.Action,
                }
            })
            .ToListAsync());
    }

    public async Task<bool> CreateUserAccess(string userId, int accessListId, int accessListActionId)
    {
        return await CreateAsync(new UserAccess
        {
            UserId = userId,
            AccessListId = accessListId,
            AccessListActionId = accessListActionId
        });
    }
}
