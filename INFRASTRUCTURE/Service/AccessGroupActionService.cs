
using APPLICATION.Dto.AccessGroupAction;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AccessGroupActionService:GenericService<AccessGroupAction, GetAccessGroupActionDto>, IAccessGroupActionService
{
    public AccessGroupActionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
