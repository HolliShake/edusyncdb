
using APPLICATION.Dto.User;
using APPLICATION.Dto.Vision;
using APPLICATION.IService.CoreData;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class VisionService: GenericService<Vision, GetVisionDto>, IVisionService
{
    public VisionService(AppDbContext context, IMapper mapper): base(context, mapper)
    {
    }
}