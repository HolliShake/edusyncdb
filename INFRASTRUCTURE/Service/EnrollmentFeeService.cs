
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

    public async Task<ICollection<GetEnrollmentFeeDto>> GetEnrollmentFeesByObjectId(int objectId)
    {
        return _mapper.Map<ICollection<GetEnrollmentFeeDto>>(await _dbModel.Where(ef => ef.ObjectId == objectId).ToListAsync());
    }

    public async Task<ICollection<GetEnrollmentFeeDto>> GetEnrollmentFeesByFundSourceId(int fundSourceId)
    {
        return _mapper.Map<ICollection<GetEnrollmentFeeDto>>(await _dbModel.Where(ef => ef.FundSourceId == fundSourceId).ToListAsync());
    }
}
