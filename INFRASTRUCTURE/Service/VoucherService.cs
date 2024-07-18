using APPLICATION.Dto.Voucher;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class VoucherService:GenericService<Voucher, GetVoucherDto>, IVoucherService
{
    public VoucherService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
