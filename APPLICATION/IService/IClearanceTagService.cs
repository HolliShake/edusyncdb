using APPLICATION.Dto.ClearanceTag;
using DOMAIN.Model;
namespace APPLICATION.IService; 
public interface IClearanceTagService : IGenericService<ClearanceTag, GetClearanceTagDto> 
{ 
    public Task<ICollection<GetClearanceTagDto>> GetClearanceTagsByClearanceTypeId(int clearanceTypeId); 
}
