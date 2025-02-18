
using APPLICATION.Dto.EnrollmentFee;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service.BillingAndFee;

public class EnrollmentFeeService:GenericService<EnrollmentFee, GetEnrollmentFeeDto>, IEnrollmentFeeService
{
    public EnrollmentFeeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetEnrollmentFeeDto>> GetAllAsync()
    {
        var enrollmentFees = await _dbModel
        .Include(ef => ef.Object)
        .Include(ef => ef.FundSource)
        .ToListAsync();
        return _mapper.Map<ICollection<GetEnrollmentFeeDto>>(enrollmentFees);
    }

    public async new Task<EnrollmentFee?> GetAsync(int id)
    {
        var enrollmentFee = await _dbModel
        .Include(ef => ef.Object)
        .Include(ef => ef.FundSource)
        .Where(ef => ef.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return enrollmentFee;
    }

    public async new Task<GetEnrollmentFeeDto?> CreateAsync(EnrollmentFee newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.Object = _dbContext.TableObjects.Find(newItem.ObjectId);
            newItem.FundSource = _dbContext.FundSources.Find(newItem.FundSourceId);
            return _mapper.Map<GetEnrollmentFeeDto>(newItem);
        }
        return null;
    }

    public async new Task<GetEnrollmentFeeDto?> UpdateAsync(EnrollmentFee updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.Object = _dbContext.TableObjects.Find(updatedItem.ObjectId);
            updatedItem.FundSource = _dbContext.FundSources.Find(updatedItem.FundSourceId);
            return _mapper.Map<GetEnrollmentFeeDto>(updatedItem);
        }
        return null;
    }

    public async Task<ICollection<GetEnrollmentFeeDto>> GetEnrollmentFeesByObjectId(int objectId)
    {
        var enrollmentFees = await _dbModel
        .Include(ef => ef.Object)
        .Include(ef => ef.FundSource)
        .Where(ef => ef.ObjectId == objectId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetEnrollmentFeeDto>>(enrollmentFees);
    }

    public async Task<ICollection<GetEnrollmentFeeDto>> GetEnrollmentFeesByFundSourceId(int fundSourceId)
    {
        var enrollmentFees = await _dbModel
        .Include(ef => ef.Object)
        .Include(ef => ef.FundSource)
        .Where(ef => ef.FundSourceId == fundSourceId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetEnrollmentFeeDto>>(enrollmentFees);
    }
}
