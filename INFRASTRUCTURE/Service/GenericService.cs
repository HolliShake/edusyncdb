using APPLICATION.IService;
using AutoMapper;
using INFRASTRUCTURE.Data;
using INFRASTRUCTURE.ErrorHandler;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;

public class GenericService <TModel, TGetter> : IGenericService<TModel, TGetter> where TModel : class where TGetter : class
{
    protected readonly AppDbContext _dbContext;
    protected readonly DbSet<TModel> _dbModel;
    protected readonly IMapper _mapper;

    public GenericService(AppDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _dbModel = _dbContext.Set<TModel>();
        _mapper = mapper;
    }

    public async Task<ICollection<TGetter>> GetAllAsync()
    {
        return _mapper.Map<ICollection<TGetter>>(await _dbModel.ToListAsync());
    }
    
    public async Task<ICollection<TGetter>> GetByChunk(int max)
    {
        return _mapper.Map<ICollection<TGetter>>(await _dbModel.Take(max).ToListAsync());
    }

    public async Task<TModel?> GetAsync(int id)
    {
        return await _dbModel.FindAsync(id);
    }

    public async Task<TGetter?> CreateAsync(TModel newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            return _mapper.Map<TGetter>(newItem);
        }
        return null;
    }

    public async Task<ICollection<TGetter>?> CreateAllAsync(List<TModel> newItems)
    {
        await _dbModel.AddRangeAsync(newItems);
        if (await Save())
        {
            return _mapper.Map<ICollection<TGetter>>(newItems);
        }
        return null;
    }

    public async Task<TGetter?> UpdateAsync(TModel updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            return _mapper.Map<TGetter>(updatedItem);
        }
        return null;
    }

    public async Task<bool> DeleteSync(TModel oldItem)
    {
        _dbModel.Remove(oldItem);
        return await Save();
    }

    protected async Task<bool> Save()
    {
        return ((await _dbContext.SaveChangesAsync()) > 0);
    }
}