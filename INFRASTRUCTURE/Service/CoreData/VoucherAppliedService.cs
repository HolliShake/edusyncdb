using AutoMapper;
using APPLICATION.Dto.VoucherApplied;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class VoucherAppliedService:GenericService<VoucherApplied, GetVoucherAppliedDto>, IVoucherAppliedService
{
    public VoucherAppliedService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
