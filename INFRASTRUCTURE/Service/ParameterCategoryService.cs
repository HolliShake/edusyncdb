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
        return _mapper.Map<ICollection<GetParameterCategoryDto>>(await _dbModel
            .Include(pc => pc.Instrument)
            .ToListAsync());
    }
    
    public async new Task<GetParameterCategoryDto?> GetAsync(int id)
    {
        return _mapper.Map<GetParameterCategoryDto?>(await _dbModel
            .Include(pc => pc.Instrument)
            .Where(pc => pc.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(ParameterCategory newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.Instrument = await _dbContext.Instruments.FindAsync(newItem.InstrumentId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(ParameterCategory updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.Instrument = await _dbContext.Instruments.FindAsync(updatedItem.InstrumentId);
        }
        return result;
    }
}
