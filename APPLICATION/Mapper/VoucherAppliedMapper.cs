using AutoMapper;
using APPLICATION.Dto.VoucherApplied;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class VoucherAppliedMapper : Profile
{
    public VoucherAppliedMapper()
    {
        CreateMap<VoucherAppliedDto, VoucherApplied>();
        CreateMap<VoucherApplied, GetVoucherAppliedDto>();
    }
}
