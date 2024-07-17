using AutoMapper;
using APPLICATION.Dto.FundSource;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class FundSourceMapper : Profile
{
    public FundSourceMapper()
    {
        CreateMap<FundSourceDto, FundSource>();
        CreateMap<FundSource, GetFundSourceDto>();
    }
}
