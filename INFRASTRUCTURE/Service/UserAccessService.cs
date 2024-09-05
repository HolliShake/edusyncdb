
using APPLICATION.Dto.UserAccess;
using APPLICATION.Dto.AccessList;
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using APPLICATION.Dto.AccessGroup;
using APPLICATION.Dto.AccessListAction;

namespace INFRASTRUCTURE.Service;
public class UserAccessService(AppDbContext context, IMapper mapper) : GenericService<UserAccess, GetUserAccessDto>(context, mapper), IUserAccessService
{
    public async Task<ICollection<UserAccessGroupedBy>> GetUserAccessByUserId(string userId)
    {
        return await _dbModel
            .Include(ua => ua.AccessList)
                .ThenInclude(al => al.AccessGroup)
            .Include(ua => ua.AccessListAction)
            .Where(ua => ua.UserId == userId)
            .GroupBy(ua => ua.AccessList.AccessGroup)
            .Select(ag => new UserAccessGroupedBy
            {
                AccessGroup = _mapper.Map<GetAccessGroupDto>(ag.Key),
                UserAccesses = _mapper.Map<ICollection<GetUserAccessDto>>(ag.Select(ua => new GetUserAccessDto
                {
                    Id = ua.Id,
                    UserId = ua.UserId,
                    AccessListId = ua.AccessListId,
                    AccessList = new GetAccessListDto
                    {
                        Id = ua.AccessList.Id,
                        Subject = ua.AccessList.Subject,
                    },
                    AccessListActionId = ua.AccessListActionId,
                    AccessListAction = new GetAccessListActionDto
                    {
                        Id = ua.AccessListAction.Id,
                        Action = ua.AccessListAction.Action,
                    }
                }))
            })
            .ToListAsync();
    }

    public ICollection<UserAccessGroupedBy> GetUserAccessByUserIdSync(string userId)
    {
        return _dbModel
            .Include(ua => ua.AccessList)
                .ThenInclude(al => al.AccessGroup)
            .Include(ua => ua.AccessListAction)
            .Where(ua => ua.UserId == userId)
            .GroupBy(ua => ua.AccessList.AccessGroup)
            .Select(ag => new UserAccessGroupedBy
            {
                AccessGroup = _mapper.Map<GetAccessGroupDto>(ag.Key),
                UserAccesses = _mapper.Map<ICollection<GetUserAccessDto>>(ag.Select(ua => new GetUserAccessDto
                {
                    Id = ua.Id,
                    UserId = ua.UserId,
                    AccessListId = ua.AccessListId,
                    AccessList = new GetAccessListDto
                    {
                        Id = ua.AccessList.Id,
                        Subject = ua.AccessList.Subject,
                    },
                    AccessListActionId = ua.AccessListActionId,
                    AccessListAction = new GetAccessListActionDto
                    {
                        Id = ua.AccessListAction.Id,
                        Action = ua.AccessListAction.Action,
                    },
                }))
            })
            .ToList();
    }

    public async Task<ICollection<UserAccessGroupedBy>> TestAccessList(string userId)
    {
        return await _dbModel
            .Include(ua => ua.AccessList)
                .ThenInclude(al => al.AccessGroup)
            .Include(ua => ua.AccessListAction)
            .Where(ua => ua.UserId == userId)
            .GroupBy(ua => ua.AccessList.AccessGroup)
            .Select(ag => new UserAccessGroupedBy
            {
                AccessGroup = _mapper.Map<GetAccessGroupDto>(ag.Key),
                UserAccesses = _mapper.Map<ICollection<GetUserAccessDto>>(ag.Select(ua => new GetUserAccessDto
                {
                    Id = ua.Id,
                    UserId = ua.UserId,
                    AccessListId = ua.AccessListId,
                    AccessList = new GetAccessListDto
                    {
                        Id = ua.AccessList.Id,
                        Subject = ua.AccessList.Subject,
                    },
                    AccessListActionId = ua.AccessListActionId,
                    AccessListAction = new GetAccessListActionDto
                    {
                        Id = ua.AccessListAction.Id,
                        Action = ua.AccessListAction.Action,
                    }
                }))
            })
            .ToListAsync();
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
        List<GetUserAccessDto> newItems = [];
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
