
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class VoucherAppliedService:GenericService<VoucherApplied>, IVoucherAppliedService
{
    public VoucherAppliedService(AppDbContext context):base(context)
    {
    }
}
