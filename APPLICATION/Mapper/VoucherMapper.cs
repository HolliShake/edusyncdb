using AutoMapper;
using APPLICATION.Dto.Voucher;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class VoucherMapper : Profile
{
    public VoucherMapper()
    {
        CreateMap<VoucherDto, Voucher>();
        CreateMap<Voucher, GetVoucherDto>();
    }
}
