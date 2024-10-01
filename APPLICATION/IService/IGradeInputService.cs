using APPLICATION.Dto.GradeInput;
using DOMAIN.Model;
using Microsoft.AspNetCore.Mvc;

namespace APPLICATION.IService;
public interface IGradeInputService : IGenericService<GradeInput, GetGradeInputDto>
{
}
