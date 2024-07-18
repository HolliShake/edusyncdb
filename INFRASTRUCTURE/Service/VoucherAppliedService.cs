using APPLICATION.Dto.VoucherApplied;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class VoucherAppliedService:GenericService<VoucherApplied, GetVoucherAppliedDto>, IVoucherAppliedService
{
    public VoucherAppliedService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
