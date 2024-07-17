using AutoMapper;
using APPLICATION.Dto.LikertQuestion;
using DOMAIN.Model;

namespace APPLICATION.Mapper;
public class LikertQuestionMapper : Profile
{
    public LikertQuestionMapper()
    {
        CreateMap<LikertQuestionDto, LikertQuestion>();
        CreateMap<LikertQuestion, GetLikertQuestionDto>();
    }
}
