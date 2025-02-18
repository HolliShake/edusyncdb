using AutoMapper;
using APPLICATION.Dto.FundSource;
using APPLICATION.IService.AccountingData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.AccountingData;

public class FundSourceService:GenericService<FundSource, GetFundSourceDto>, IFundSourceService
{
    public FundSourceService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
