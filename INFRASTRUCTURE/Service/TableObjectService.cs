using APPLICATION.Dto.TableObject;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class TableObjectService:GenericService<TableObject, GetTableObjectDto>, ITableObjectService
{
    public TableObjectService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetTableObjectDto>> GetParentObject()
    {
        return _mapper.Map<ICollection<GetTableObjectDto>>(await _dbModel.Where(p => p.ParentId == null).ToListAsync());
    }

    public async Task<ICollection<GetTableObjectDto>> GetObjectByAccountGroupId(int accountGroupId)
    {
        return _mapper.Map<ICollection<GetTableObjectDto>>(await _dbModel.Where(p => p.AccountGroupId == accountGroupId).ToListAsync());
    }
}
