
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class EnrollmentBillingService:GenericService<EnrollmentBilling>, IEnrollmentBillingService
{
    public EnrollmentBillingService(AppDbContext context):base(context)
    {
    }

    public async Task<ICollection<EnrollmentBilling>> GetEnrollmentBillingsByEnrollmentId(int enrollmentId)
    {
        return await _dbModel
            .Include(eb => eb.Enrollment)
            .Include(eb => eb.EnrollmentFee)
            .Include(eb => eb.Cycle)
            .Include(eb => eb.Voucher)
            .Where(eb => eb.EnrollmentId == enrollmentId)
            .ToListAsync();
    }
    public async Task<ICollection<EnrollmentBilling>> GetEnrollmentBillingsByEnrollmentFeeId(int enrollmenFeetId)
    {
        return await _dbModel
            .Include(eb => eb.Enrollment)
            .Include(eb => eb.EnrollmentFee)
            .Include(eb => eb.Cycle)
            .Include(eb => eb.Voucher)
            .Where(eb => eb.EnrollmentFeeId == enrollmenFeetId)
            .ToListAsync();
    }
    public async Task<ICollection<EnrollmentBilling>> GetEnrollmentBillingsByCycleId(int cycleId)
    {
        return await _dbModel
            .Include(eb => eb.Enrollment)
            .Include(eb => eb.EnrollmentFee)
            .Include(eb => eb.Cycle)
            .Include(eb => eb.Voucher)
            .Where(eb => eb.CycleId == cycleId)
            .ToListAsync();
    }
    public async Task<ICollection<EnrollmentBilling>> GetEnrollmentBillingsByVoucherId(int voucherId)
    {
        return await _dbModel
            .Include(eb => eb.Enrollment)
            .Include(eb => eb.EnrollmentFee)
            .Include(eb => eb.Cycle)
            .Include(eb => eb.Voucher)
            .Where(eb => eb.VoucherId == voucherId)
            .ToListAsync();
    }
}
