using AutoMapper;
using APPLICATION.Dto.ProgramType;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class ProgramTypeMapper : Profile
{
    public ProgramTypeMapper()
    {
        CreateMap<ProgramTypeDto, ProgramType>();
        CreateMap<ProgramType, GetProgramTypeDto>();
    }
}
