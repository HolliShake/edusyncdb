using APPLICATION.Dto.AccessListAction;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class AccessListActionService:GenericService<AccessListAction, GetAccessListActionDto>, IAccessListActionService
{
    public AccessListActionService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetAccessListActionDto>> GetAccessListActionsByAccessListId(int accessListId)
    {
        return _mapper.Map<ICollection<GetAccessListActionDto>>(await _dbModel.Where(ala => ala.AccessListId == accessListId).ToListAsync());
    }
}
