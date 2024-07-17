using AutoMapper;
using APPLICATION.Dto.AccountGroup;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AccountGroupMapper : Profile
{
    public AccountGroupMapper()
    {
        CreateMap<AccountGroupDto, AccountGroup>();
        CreateMap<AccountGroup, GetAccountGroupDto>();
    }
}
