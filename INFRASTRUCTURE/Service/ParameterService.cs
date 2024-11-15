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
        var parameters = await _dbModel
        .Include(p => p.ParameterSubCategory)
        .ToListAsync();
        return _mapper.Map<ICollection<GetParameterDto>>(parameters);
    }

    public async new Task<Parameter?> GetAsync(int id)
    {
        var parameter = await _dbModel
        .Include(p => p.ParameterSubCategory)
        .Where(p => p.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return parameter;
    }

    public async new Task<GetParameterDto?> CreateAsync(Parameter newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.ParameterSubCategory = _dbContext.ParameterSubCategories.Find(newItem.ParameterSubCategoryId);
            return _mapper.Map<GetParameterDto>(newItem);
        }
        return null;
    }

    public async new Task<GetParameterDto?> UpdateAsync(Parameter updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.ParameterSubCategory = _dbContext.ParameterSubCategories.Find(updatedItem.ParameterSubCategoryId);
            return _mapper.Map<GetParameterDto>(updatedItem);
        }
        return null;
    }
}
