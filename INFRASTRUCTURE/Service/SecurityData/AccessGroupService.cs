using AutoMapper;
using APPLICATION.Dto.AccessGroup;
using APPLICATION.IService.SecurityData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service.SecurityData;

public class AccessGroupService : GenericService<AccessGroup, GetAccessGroupDto>, IAccessGroupService
{
    public AccessGroupService(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async new Task<ICollection<GetAccessGroupDto>> GetAllAsync()
    {
        var accessGroups = await _dbModel
        .Include(ag => ag.AccessGroupActions)
        .ToListAsync();
        return _mapper.Map<ICollection<GetAccessGroupDto>>(accessGroups);
    }

    public async new Task<GetAccessGroupDto?> GetAsync(int id)
    {
        var accessGroup = await _dbModel
        .Include(ag => ag.AccessGroupActions)
        .Where(ag => ag.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return _mapper.Map<GetAccessGroupDto?>(accessGroup);
    }
}