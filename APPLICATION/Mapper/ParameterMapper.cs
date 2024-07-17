using AutoMapper;
using APPLICATION.Dto.Parameter;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ParameterMapper : Profile
{
    public ParameterMapper()
    {
        CreateMap<ParameterDto, Parameter>();
        CreateMap<Parameter, GetParameterDto>();
    }
}
