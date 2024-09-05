using APPLICATION.Dto.LikertQuestion;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class LikertQuestionService:GenericService<LikertQuestion, GetLikertQuestionDto>, ILikertQuestionService
{
    public LikertQuestionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }


    public async new Task<ICollection<GetLikertQuestionDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetLikertQuestionDto>>(await _dbModel
            .Include(lq => lq.Parameter)
            .ToListAsync());
    }

    public async new Task<LikertQuestion?> GetAsync(int id)
    {
        return _mapper.Map<LikertQuestion?>(await _dbModel
            .Include(lq => lq.Parameter)
            .Where(lq => lq.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(LikertQuestion newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.Parameter = await _dbContext.Parameters.FindAsync(newItem.ParameterId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(LikertQuestion updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.Parameter = await _dbContext.Parameters.FindAsync(updatedItem.ParameterId);
        }
        return result;
    }
}
