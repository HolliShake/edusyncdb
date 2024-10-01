
using APPLICATION.Dto.UserAccessGroupDetails;
using APPLICATION.Dto.UserCampusDetails;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace INFRASTRUCTURE.Service;
public class UserAccessGroupDetailsService:GenericService<UserAccessGroupDetails, GetUserAccessGroupDetailsDto>, IUserAccessGroupDetailsService
{
    public UserAccessGroupDetailsService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetUserAccessGroupDetailsDto>> GetUserAccessGroupByUserGuid(string userGuid)
    {
        return _mapper.Map<ICollection<GetUserAccessGroupDetailsDto>>(await _dbModel
            .Include(uagd => uagd.AccessGroupAction)
                .ThenInclude(aga => aga.AccessGroup)
            .Where(uagd => uagd.UserId == userGuid)
            .ToListAsync());
    }

    public async Task<object> GetUserAccessByUserGuid(string userGuid)
    {
        return await _dbModel
            .Include(uagd => uagd.AccessGroupAction)
            .Where(uagd => uagd.UserId == userGuid)
            .GroupBy(uagd => uagd.AccessGroupAction.AccessGroupId)
            .Select(uagdArray => new {
                Id = uagdArray.First().AccessGroupAction.AccessGroupId,
                AccessGroup = uagdArray.First().AccessGroupAction.AccessGroup.AccessGroupName,
                Actions = uagdArray.Select(uagd => new {
                    Id = uagd.AccessGroupAction.Id,
                    Action = uagd.AccessGroupAction.Action
                })
            })
            .ToListAsync();
    }
    public ICollection<GetUserAccessGroupDetailsDto> GetUserAccessGroupByUserGuidSync(string userGuid)
    {
        return _mapper.Map<ICollection<GetUserAccessGroupDetailsDto>>(_dbModel
            .Include(uagd => uagd.AccessGroupAction)
                .ThenInclude(aga => aga.AccessGroup)
            .Where(uagd => uagd.UserId == userGuid)
            .ToList());
    }

    public async Task<object?> CreateMultipleUserAccess(UserCampusDetailMultipleAccessGroupActionDto item)
    {
        List<UserAccessGroupDetails> userAccessGroupDetails = [];
        foreach (var accessGroupActionId in item.AccessGroupActionIds)
        {
            userAccessGroupDetails.Add(new UserAccessGroupDetails
            {
                UserId = item.UserId,
                AccessGroupActionId = accessGroupActionId
            });
        }
        await _dbModel.AddRangeAsync(userAccessGroupDetails);
        var result = await Save();
        if (result)
        {
            foreach (var userAccessGroupDetail in userAccessGroupDetails)
            {
                userAccessGroupDetail.AccessGroupAction = _dbContext.AccessGroupActions
                        .Include(aga => aga.AccessGroup)
                        .Where(aga => aga.Id == userAccessGroupDetail.AccessGroupActionId)
                        .FirstOrDefault();
            }
            return (new
            {
                UserId = item.UserId,
                AccessGroupActions = userAccessGroupDetails.Select(uagd => new
                {
                    Id = uagd.Id,
                    AccessGroupActionId = uagd.AccessGroupActionId,
                    AccessGroupAction = uagd.AccessGroupAction
                }).ToList()
            });
        }
        return null;
    }

    public async Task<bool> DeleteMultipleUserAccess(UserCampusDetailMultipleAccessGroupActionDto item)
    {
        List<UserAccessGroupDetails> userAccessGroupDetails = [];
        foreach (var accessGroupActionId in item.AccessGroupActionIds)
        {
            var current = _dbModel
                .Where(uagd => uagd.UserId == item.UserId)
                .Where(uagd => uagd.AccessGroupActionId == accessGroupActionId)
                .ToList();

            if (current == null || current.Count <= 0)
            {
                continue;
            }

            userAccessGroupDetails.AddRange(current);
        }
        _dbModel.RemoveRange(userAccessGroupDetails);
        return await Save();
    }
}
