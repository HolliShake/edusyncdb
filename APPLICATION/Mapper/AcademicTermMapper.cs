using AutoMapper;
using APPLICATION.Dto.AcademicTerm;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AcademicTermMapper : Profile
{
    public AcademicTermMapper()
    {
        CreateMap<AcademicTermDto, AcademicTerm>();
        CreateMap<AcademicTerm, GetAcademicTermDto>();
    }
}
