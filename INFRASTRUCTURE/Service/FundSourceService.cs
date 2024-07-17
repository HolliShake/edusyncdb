
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class FundSourceService:GenericService<FundSource>, IFundSourceService
{
    public FundSourceService(AppDbContext context):base(context)
    {
    }
}
