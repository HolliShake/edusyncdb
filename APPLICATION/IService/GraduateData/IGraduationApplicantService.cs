using APPLICATION.Dto.GraduationApplicant;
using DOMAIN.Model;

namespace APPLICATION.IService.GraduateData;

public interface IGraduationApplicantService:IGenericService<GraduationApplicant, GetGraduationApplicantDto>
{
}
