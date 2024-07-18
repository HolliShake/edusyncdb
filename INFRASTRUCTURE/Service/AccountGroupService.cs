
using APPLICATION.Dto.AccountGroup;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AccountGroupService:GenericService<AccountGroup, GetAccountGroupDto>, IAccountGroupService
{
    public AccountGroupService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
