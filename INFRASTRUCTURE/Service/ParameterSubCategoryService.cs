using APPLICATION.Dto.ParameterSubCategory;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ParameterSubCategoryService:GenericService<ParameterSubCategory, GetParameterSubCategoryDto>, IParameterSubCategoryService
{
    public ParameterSubCategoryService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetParameterSubCategoryDto>> GetAllAsync()
    {
        var parameterSubCategories = await _dbModel
        .Include(psc => psc.ParameterCategory)
        .ToListAsync();
        return _mapper.Map<ICollection<GetParameterSubCategoryDto>>(parameterSubCategories);
    }

    public async new Task<ParameterSubCategory?> GetAsync(int id)
    {
        var parameterSubCategory = await _dbModel
        .Include(psc => psc.ParameterCategory)
        .Where(psc => psc.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return parameterSubCategory;
    }

    public async new Task<GetParameterSubCategoryDto?> CreateAsync(ParameterSubCategory newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.ParameterCategory = _dbContext.ParameterCategories.Find(newItem.ParameterCategoryId);
            return _mapper.Map<GetParameterSubCategoryDto>(newItem);
        }
        return null;
    }

    public async new Task<GetParameterSubCategoryDto?> UpdateAsync(ParameterSubCategory updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.ParameterCategory = _dbContext.ParameterCategories.Find(updatedItem.ParameterCategoryId);
            return _mapper.Map<GetParameterSubCategoryDto>(updatedItem);
        }
        return null;
    }
}
