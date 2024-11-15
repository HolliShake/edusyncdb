using AutoMapper;
using APPLICATION.Dto.CollegeDean;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class CollegeDeanMapper : Profile
{
    public CollegeDeanMapper()
    {
        CreateMap<CollegeDeanDto, CollegeDean>();
        CreateMap<CollegeDean, GetCollegeDeanDto>();
    }
}
