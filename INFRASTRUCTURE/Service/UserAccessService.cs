
using APPLICATION.Dto.UserAccess;
using APPLICATION.Dto.AccessList;
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;

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

    public async Task<List<GetUserAccessDto>?> UpdateUserAccess(List<UpdateUserAccessDto> items)
    {
        List<GetUserAccessDto> newItems = new();
        int success = 0;
        foreach (var item in items)
        {
            switch (item.Mode)
            {
                case UserAccessUpdateMode.CREATE:
                    {
                        UserAccess current;
                        var result = await this.CreateAsync(current = new UserAccess
                        {
                            UserId = item.UserId,
                            AccessListId = item.AccessListId,
                            AccessListActionId = item.AccessListActionId
                        });
                        newItems.Add(_mapper.Map<GetUserAccessDto>(current));
                        if (result) ++success;
                        break;
                    }
                case UserAccessUpdateMode.UPDATE:
                    {
                        var userAccess = await _dbModel.FindAsync(item.Id);
                        if (userAccess == null)
                        {
                            break;
                        }
                        userAccess.UserId = item.UserId;
                        userAccess.AccessListId = item.AccessListId;
                        userAccess.AccessListActionId = item.AccessListActionId;
                        var result = await this.UpdateSync(userAccess);
                        if (result) ++success;
                        break;
                    }
                case UserAccessUpdateMode.DELETE:
                    {
                        var userAccess = await _dbModel.FindAsync(item.Id);
                        if (userAccess == null)
                        {
                            break;
                        }
                        var result = await this.DeleteSync(userAccess);
                        if (result) ++success;
                        break;
                    }
            }
        }

        return (success == items.Count)
            ? newItems
            : null;
    }
}
