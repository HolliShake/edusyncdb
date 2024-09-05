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

    public async new Task<ICollection<GetTableObjectDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetTableObjectDto>>(await _dbModel
            .Include(to => to.AccountGroup)
            .ToListAsync());
    }

    public async new Task<GetTableObjectDto?> GetAsync(int id)
    {
        return _mapper.Map<GetTableObjectDto?>(await _dbModel
            .Include(to => to.AccountGroup)
            .Where(to => to.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(TableObject newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.AccountGroup = await _dbContext.AccountGroups.FindAsync(newItem.AccountGroupId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(TableObject updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.AccountGroup = await _dbContext.AccountGroups.FindAsync(updatedItem.AccountGroupId);
        }
        return result;
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
