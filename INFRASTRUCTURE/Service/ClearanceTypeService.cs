
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ClearanceTypeService:GenericService<ClearanceType>, IClearanceTypeService
{
    public ClearanceTypeService(AppDbContext context):base(context)
    {
    }
}
