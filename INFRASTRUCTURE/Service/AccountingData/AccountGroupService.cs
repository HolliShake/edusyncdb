using AutoMapper;
using APPLICATION.Dto.AccountGroup;
using APPLICATION.IService.AccountingData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.AccountingData;

public class AccountGroupService:GenericService<AccountGroup, GetAccountGroupDto>, IAccountGroupService
{
    public AccountGroupService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
