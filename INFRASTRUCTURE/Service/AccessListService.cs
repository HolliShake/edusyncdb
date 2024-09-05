using APPLICATION.Dto.AccessList;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AccessListService:GenericService<AccessList, GetAccessListDto>, IAccessListService
{
    public AccessListService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public new async Task<ICollection<GetAccessListDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetAccessListDto>>(await _dbModel
            .Include(al => al.AccessGroup)
            .Include(al => al.AccessListActions).ToListAsync());
    }
    
    public new async Task<AccessList?> GetAsync(int id)
    {
        return _mapper.Map<AccessList?>(await _dbModel
                .Include(al => al.AccessGroup)
                .Include(al => al.AccessListActions)
                    .ThenInclude(ala => ala.AccessList)
                .Where(al => al.Id == id)
                .FirstOrDefaultAsync());
    }

    public async Task<object> GetByAccessGroupId(int accessGroupId)
    {
        return await _dbModel
            .Include(al => al.AccessGroup)
            .Include(al => al.AccessListActions)
                .ThenInclude(ala => ala.AccessList)
            .Where(al => al.AccessGroupId == accessGroupId)
            .ToListAsync();
    }
}