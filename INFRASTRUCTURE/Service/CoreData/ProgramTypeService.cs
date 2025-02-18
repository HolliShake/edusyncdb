using AutoMapper;
using APPLICATION.Dto.ProgramType;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class ProgramTypeService:GenericService<ProgramType, GetProgramTypeDto>, IProgramTypeService
{
    public ProgramTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
