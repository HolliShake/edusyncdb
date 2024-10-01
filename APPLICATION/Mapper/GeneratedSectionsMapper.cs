using AutoMapper;
using APPLICATION.Dto.GeneratedSections;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class GeneratedSectionsMapper : Profile
{
    public GeneratedSectionsMapper()
    {
        CreateMap<GeneratedSectionsDto, GeneratedSections>();
        CreateMap<GeneratedSections, GetGeneratedSectionsDto>();
    }
}
