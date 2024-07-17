
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AgencyService:GenericService<Agency>, IAgencyService
{
    public AgencyService(AppDbContext context):base(context)
    {
    }
}
