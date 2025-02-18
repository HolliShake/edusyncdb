using AutoMapper;
using APPLICATION.Dto.Voucher;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class VoucherService:GenericService<Voucher, GetVoucherDto>, IVoucherService
{
    public VoucherService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
