
using APPLICATION.Dto.UserAccessGroupDetails;
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
}
