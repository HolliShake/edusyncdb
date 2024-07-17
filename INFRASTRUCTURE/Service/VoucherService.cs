
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class VoucherService:GenericService<Voucher>, IVoucherService
{
    public VoucherService(AppDbContext context):base(context)
    {
    }
}
