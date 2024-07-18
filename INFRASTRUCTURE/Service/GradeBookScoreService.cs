using APPLICATION.Dto.GradeBookScore;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GradeBookScoreService:GenericService<GradeBookScore, GetGradeBookScoreDto>, IGradeBookScoreService
{
    public GradeBookScoreService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
