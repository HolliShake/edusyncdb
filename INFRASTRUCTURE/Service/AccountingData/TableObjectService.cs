using AutoMapper;
using APPLICATION.Dto.TableObject;
using APPLICATION.IService.AccountingData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service.AccountingData;

public class TableObjectService:GenericService<TableObject, GetTableObjectDto>, ITableObjectService
{
    public TableObjectService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetTableObjectDto>> GetAllAsync()
    {
        var tableObject = await _dbModel
        .Include(to => to.AccountGroup)
        .ToListAsync();
        return _mapper.Map<ICollection<GetTableObjectDto>>(tableObject);
    }

    public async new Task<TableObject?> GetAsync(int id)
    {
        var tableObject = await _dbModel
        .Include(to => to.AccountGroup)
        .Where(to => to.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return tableObject;
    }

    public async new Task<GetTableObjectDto?> CreateAsync(TableObject newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.AccountGroup = _dbContext.AccountGroups.Find(newItem.AccountGroupId);
            return _mapper.Map<GetTableObjectDto>(newItem);
        }
        return null;
    }

    public async new Task<GetTableObjectDto?> UpdateAsync(TableObject updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.AccountGroup = _dbContext.AccountGroups.Find(updatedItem.AccountGroupId);
            return _mapper.Map<GetTableObjectDto>(updatedItem);
        }
        return null;
    }

    public async Task<ICollection<GetTableObjectDto>> GetParentObject()
    {
        var parentObject = await _dbModel
        .Where(p => p.ParentId == null)
        .ToListAsync();
        return _mapper.Map<ICollection<GetTableObjectDto>>(parentObject);
    }

    public async Task<ICollection<GetTableObjectDto>> GetObjectByAccountGroupId(int accountGroupId)
    {
        var tableObject = await _dbModel
        .Where(p => p.AccountGroupId == accountGroupId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetTableObjectDto>>(tableObject);
    }
}
