using APPLICATION.Dto.ProgramType;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ProgramTypeService:GenericService<ProgramType, GetProgramTypeDto>, IProgramTypeService
{
    public ProgramTypeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
