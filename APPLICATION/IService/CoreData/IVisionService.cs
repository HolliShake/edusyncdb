using APPLICATION.Dto.Vision;
using DOMAIN.Model;

namespace APPLICATION.IService.CoreData;

public interface IVisionService : IGenericService<Vision, GetVisionDto>
{
}