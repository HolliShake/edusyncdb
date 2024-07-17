using AutoMapper;
using APPLICATION.Dto.AdmissionScore;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class AdmissionScoreMapper : Profile
{
    public AdmissionScoreMapper()
    {
        CreateMap<AdmissionScoreDto, AdmissionScore>();
        CreateMap<AdmissionScore, GetAdmissionScoreDto>();
    }
}
