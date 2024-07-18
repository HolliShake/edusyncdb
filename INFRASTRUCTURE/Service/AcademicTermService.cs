using APPLICATION.Dto.AcademicTerm;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AcademicTermService:GenericService<AcademicTerm, GetAcademicTermDto>, IAcademicTermService
{
    public AcademicTermService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
