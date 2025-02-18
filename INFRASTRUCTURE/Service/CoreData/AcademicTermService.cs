using AutoMapper;
using APPLICATION.Dto.AcademicTerm;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class AcademicTermService:GenericService<AcademicTerm, GetAcademicTermDto>, IAcademicTermService
{
    public AcademicTermService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
