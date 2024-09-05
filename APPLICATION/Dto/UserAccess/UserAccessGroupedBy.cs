
using APPLICATION.Dto.AccessGroup;
using APPLICATION.Dto.AccessList;

namespace APPLICATION.Dto.UserAccess;

public class UserAccessGroupedBy
{
    public GetAccessGroupDto AccessGroup { get; set; }
    public ICollection<GetUserAccessDto> UserAccesses { get; set; }
}