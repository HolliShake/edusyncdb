using APPLICATION.Dto.Parameter;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class ParameterService:GenericService<Parameter, GetParameterDto>, IParameterService
{
    public ParameterService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
