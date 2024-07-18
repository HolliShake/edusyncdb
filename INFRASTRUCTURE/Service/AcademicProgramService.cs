using APPLICATION.Dto.AcademicProgram;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AcademicProgramService:GenericService<AcademicProgram, GetAcademicProgramDto>, IAcademicProgramService
{
    public AcademicProgramService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
