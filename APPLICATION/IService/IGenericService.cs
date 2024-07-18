namespace APPLICATION.IService;

public interface IGenericService<TModel, TGetter>
{
    public Task<ICollection<TGetter>> GetAllAsync();
    public Task<ICollection<TGetter>> GetByChunk(int max);
    public Task<TModel?> GetAsync(int id);
    public Task<bool> CreateAsync(TModel newItem);
    public Task<bool> CreateAllAsync(IList<TModel> newItems);
    public Task<bool> UpdateSync(TModel updatedItem);
    public Task<bool> DeleteSync(TModel oldItem);
}

