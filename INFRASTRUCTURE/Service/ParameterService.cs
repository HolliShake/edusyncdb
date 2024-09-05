using APPLICATION.Dto.Parameter;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ParameterService:GenericService<Parameter, GetParameterDto>, IParameterService
{
    public ParameterService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetParameterDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetParameterDto>>(await _dbModel
            .Include(p => p.ParameterSubCategory)
            .ToListAsync());
    }

    public async new Task<GetParameterDto?> GetAsync(int id)
    {
        return _mapper.Map<GetParameterDto?>(await _dbModel
            .Include(p => p.ParameterSubCategory)
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(Parameter newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.ParameterSubCategory = await _dbContext.ParameterSubCategories.FindAsync(newItem.ParameterSubCategoryId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(Parameter updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.ParameterSubCategory = await _dbContext.ParameterSubCategories.FindAsync(updatedItem.ParameterSubCategoryId);
        }
        return result;
    }
}
