using AutoMapper;
using APPLICATION.Dto.ClearanceType;
using APPLICATION.IService.EClearanceData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EClearanceData;

public class ClearanceTypeService:GenericService<ClearanceType, GetClearanceTypeDto>, IClearanceTypeService
{
    public ClearanceTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
