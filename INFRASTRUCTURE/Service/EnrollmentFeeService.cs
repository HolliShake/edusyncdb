
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace INFRASTRUCTURE.Service;
public class EnrollmentFeeService:GenericService<EnrollmentFee>, IEnrollmentFeeService
{
    public EnrollmentFeeService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<EnrollmentFee>> GetEnrollmentFeesByObjectId(int objectId)
    {
        return await _dbModel.Where(ef => ef.ObjectId == objectId).ToListAsync();
    }

    public async Task<ICollection<EnrollmentFee>> GetEnrollmentFeesByFundSourceId(int fundSourceId)
    {
        return await _dbModel.Where(ef => ef.FundSourceId == fundSourceId).ToListAsync();
    }
}
