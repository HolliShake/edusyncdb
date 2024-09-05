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
        return _mapper.Map<ICollection<GetParameterSubCategoryDto>>(await _dbModel
            .Include(psc => psc.ParameterCategory)
            .ToListAsync());
    }

    public async new Task<GetParameterSubCategoryDto?> GetAsync(int id)
    {
        return _mapper.Map<GetParameterSubCategoryDto?>(await _dbModel
            .Include(psc => psc.ParameterCategory)
            .Where(psc => psc.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(ParameterSubCategory newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.ParameterCategory = await _dbContext.ParameterCategories.FindAsync(newItem.ParameterCategoryId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(ParameterSubCategory updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.ParameterCategory = await _dbContext.ParameterCategories.FindAsync(updatedItem.ParameterCategoryId);
        }
        return result;
    }
}
