
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AccountGroupService:GenericService<AccountGroup>, IAccountGroupService
{
    public AccountGroupService(AppDbContext context):base(context)
    {
    }
}
