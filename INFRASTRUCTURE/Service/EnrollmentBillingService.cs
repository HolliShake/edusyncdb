using APPLICATION.Dto.EnrollmentBilling;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class EnrollmentBillingService:GenericService<EnrollmentBilling, GetEnrollmentBillingDto>, IEnrollmentBillingService
{
    public EnrollmentBillingService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByEnrollmentId(int enrollmentId)
    {
        var enrollmentBillings = await _dbModel
        .Include(eb => eb.Enrollment)
        .Include(eb => eb.EnrollmentFee)
        .Include(eb => eb.Cycle)
        .Include(eb => eb.Voucher)
        .Where(eb => eb.EnrollmentId == enrollmentId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetEnrollmentBillingDto>>(enrollmentBillings);
    }
    public async Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByEnrollmentFeeId(int enrollmenFeetId)
    {
        var enrollmentBillings = await _dbModel
        .Include(eb => eb.Enrollment)
        .Include(eb => eb.EnrollmentFee)
        .Include(eb => eb.Cycle)
        .Include(eb => eb.Voucher)
        .Where(eb => eb.EnrollmentFeeId == enrollmenFeetId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetEnrollmentBillingDto>>(enrollmentBillings);
    }
    public async Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByCycleId(int cycleId)
    {
        var enrollmentBillings = await _dbModel
        .Include(eb => eb.Enrollment)
        .Include(eb => eb.EnrollmentFee)
        .Include(eb => eb.Cycle)
        .Include(eb => eb.Voucher)
        .Where(eb => eb.CycleId == cycleId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetEnrollmentBillingDto>>(enrollmentBillings);
    }
    public async Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByVoucherId(int voucherId)
    {
        var enrollmentBillings = await _dbModel
        .Include(eb => eb.Enrollment)
        .Include(eb => eb.EnrollmentFee)
        .Include(eb => eb.Cycle)
        .Include(eb => eb.Voucher)
        .Where(eb => eb.VoucherId == voucherId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetEnrollmentBillingDto>>(enrollmentBillings);
    }
}
