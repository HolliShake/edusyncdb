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
        var likertQuestion = await _dbModel
        .Include(lq => lq.Parameter)
        .Where(lq => lq.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return likertQuestion;
    }

    public async new Task<GetLikertQuestionDto?> CreateAsync(LikertQuestion newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.Parameter = _dbContext.Parameters.Find(newItem.ParameterId);
            return _mapper.Map<GetLikertQuestionDto>(newItem);
        }
        return null;
    }

    public async new Task<GetLikertQuestionDto?> UpdateAsync(LikertQuestion updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.Parameter = _dbContext.Parameters.Find(updatedItem.ParameterId);
            return _mapper.Map<GetLikertQuestionDto>(updatedItem);
        }
        return null;
    }
}
