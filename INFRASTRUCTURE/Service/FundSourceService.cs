using APPLICATION.Dto.FundSource;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class FundSourceService:GenericService<FundSource, GetFundSourceDto>, IFundSourceService
{
    public FundSourceService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
