using APPLICATION.Dto.Vision;
using AutoMapper;
using DOMAIN.Model;

namespace APPLICATION.Mapper;

public class VisionMapper: Profile
{
    public VisionMapper()
    {
        CreateMap<VisionDto, Vision>();
        CreateMap<Vision, GetVisionDto>();
    }
}