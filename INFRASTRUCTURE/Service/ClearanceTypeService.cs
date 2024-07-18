using APPLICATION.Dto.ClearanceType;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ClearanceTypeService:GenericService<ClearanceType, GetClearanceTypeDto>, IClearanceTypeService
{
    public ClearanceTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
