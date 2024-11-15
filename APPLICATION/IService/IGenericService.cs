
namespace APPLICATION.IService;

public interface IGenericService<TModel, TGetter>
{
    public Task<ICollection<TGetter>> GetAllAsync();
    public Task<ICollection<TGetter>> GetByChunk(int max);
    public Task<TModel?> GetAsync(int id);
    public Task<TGetter?> CreateAsync(TModel newItem);
    public Task<ICollection<TGetter>?> CreateAllAsync(List<TModel> newItems);
    public Task<TGetter?> UpdateAsync(TModel updatedItem);
    public Task<bool> DeleteSync(TModel oldItem);
}

