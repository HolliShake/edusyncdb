using AutoMapper;
using APPLICATION.Dto.AccessGroupAction;
using APPLICATION.IService.SecurityData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.SecurityData;

public class AccessGroupActionService:GenericService<AccessGroupAction, GetAccessGroupActionDto>, IAccessGroupActionService
{
    public AccessGroupActionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
