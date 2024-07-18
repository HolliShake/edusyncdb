using APPLICATION.Dto.GraduationCampus;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GraduationCampusService:GenericService<GraduationCampus, GetGraduationCampusDto>, IGraduationCampusService
{
    public GraduationCampusService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
