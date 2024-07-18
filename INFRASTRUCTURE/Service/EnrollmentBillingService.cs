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
        return _mapper.Map<ICollection<GetEnrollmentBillingDto>>(
            await _dbModel
            .Include(eb => eb.Enrollment)
            .Include(eb => eb.EnrollmentFee)
            .Include(eb => eb.Cycle)
            .Include(eb => eb.Voucher)
            .Where(eb => eb.EnrollmentId == enrollmentId)
            .ToListAsync());
    }
    public async Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByEnrollmentFeeId(int enrollmenFeetId)
    {
        return _mapper.Map<ICollection<GetEnrollmentBillingDto>>(await _dbModel
            .Include(eb => eb.Enrollment)
            .Include(eb => eb.EnrollmentFee)
            .Include(eb => eb.Cycle)
            .Include(eb => eb.Voucher)
            .Where(eb => eb.EnrollmentFeeId == enrollmenFeetId)
            .ToListAsync());
    }
    public async Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByCycleId(int cycleId)
    {
        return _mapper.Map<ICollection<GetEnrollmentBillingDto>>(await _dbModel
            .Include(eb => eb.Enrollment)
            .Include(eb => eb.EnrollmentFee)
            .Include(eb => eb.Cycle)
            .Include(eb => eb.Voucher)
            .Where(eb => eb.CycleId == cycleId)
            .ToListAsync());
    }
    public async Task<ICollection<GetEnrollmentBillingDto>> GetEnrollmentBillingsByVoucherId(int voucherId)
    {
        return _mapper.Map<ICollection<GetEnrollmentBillingDto>>(await _dbModel
            .Include(eb => eb.Enrollment)
            .Include(eb => eb.EnrollmentFee)
            .Include(eb => eb.Cycle)
            .Include(eb => eb.Voucher)
            .Where(eb => eb.VoucherId == voucherId)
            .ToListAsync());
    }
}
