using APPLICATION.Dto.ClearanceTag;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ClearanceTagService:GenericService<ClearanceTag, GetClearanceTagDto>, IClearanceTagService
{
    public ClearanceTagService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetClearanceTagDto>> GetClearanceTagsByClearanceTypeId(int clearanceTypeId)
    {
        return _mapper.Map<ICollection<GetClearanceTagDto>>(await _dbModel.Where(ct => ct.ClearanceTypeId == clearanceTypeId).ToListAsync());
    }
}
