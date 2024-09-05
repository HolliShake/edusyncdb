
using APPLICATION.Dto.EnrollmentFee;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace INFRASTRUCTURE.Service;
public class EnrollmentFeeService:GenericService<EnrollmentFee, GetEnrollmentFeeDto>, IEnrollmentFeeService
{
    public EnrollmentFeeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetEnrollmentFeeDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetEnrollmentFeeDto>>(await _dbModel
            .Include(ef => ef.Object)
            .Include(ef => ef.FundSource)
            .ToListAsync());
    }

    public async new Task<GetEnrollmentFeeDto?> GetAsync(int id)
    {
        return _mapper.Map<GetEnrollmentFeeDto?>(await _dbModel
            .Include(ef => ef.Object)
            .Include(ef => ef.FundSource)
            .Where(ef => ef.Id == id).FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(EnrollmentFee newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.Object = await _dbContext.TableObjects.FindAsync(newItem.ObjectId);
            newItem.FundSource = await _dbContext.FundSources.FindAsync(newItem.FundSourceId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(EnrollmentFee updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.Object = await _dbContext.TableObjects.FindAsync(updatedItem.ObjectId);
            updatedItem.FundSource = await _dbContext.FundSources.FindAsync(updatedItem.FundSourceId);
        }
        return result;
    }

    public async Task<ICollection<GetEnrollmentFeeDto>> GetEnrollmentFeesByObjectId(int objectId)
    {
        return _mapper.Map<ICollection<GetEnrollmentFeeDto>>(await _dbModel
            .Include(ef => ef.Object)
            .Include(ef => ef.FundSource)
            .Where(ef => ef.ObjectId == objectId).ToListAsync());
    }

    public async Task<ICollection<GetEnrollmentFeeDto>> GetEnrollmentFeesByFundSourceId(int fundSourceId)
    {
        return _mapper.Map<ICollection<GetEnrollmentFeeDto>>(await _dbModel
            .Include(ef => ef.Object)
            .Include(ef => ef.FundSource)
            .Where(ef => ef.FundSourceId == fundSourceId).ToListAsync());
    }
}
