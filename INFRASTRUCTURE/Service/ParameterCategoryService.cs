using APPLICATION.Dto.ParameterCategory;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ParameterCategoryService:GenericService<ParameterCategory, GetParameterCategoryDto>, IParameterCategoryService
{
    public ParameterCategoryService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetParameterCategoryDto>> GetAllAsync()
    {
        var parameterCategories = await _dbModel
        .Include(pc => pc.Instrument)
        .ToListAsync();
        return _mapper.Map<ICollection<GetParameterCategoryDto>>(parameterCategories);
    }
    
    public async new Task<ParameterCategory?> GetAsync(int id)
    {
        var parameterCategory = await _dbModel
        .Include(pc => pc.Instrument)
        .Where(pc => pc.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return parameterCategory;
    }

    public async new Task<GetParameterCategoryDto?> CreateAsync(ParameterCategory newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.Instrument = _dbContext.Instruments.Find(newItem.InstrumentId);
            return _mapper.Map<GetParameterCategoryDto>(newItem);
        }
        return null;
    }

    public async new Task<GetParameterCategoryDto?> UpdateAsync(ParameterCategory updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.Instrument = _dbContext.Instruments.Find(updatedItem.InstrumentId);
            return _mapper.Map<GetParameterCategoryDto>(updatedItem);
        }
        return null;
    }
}
