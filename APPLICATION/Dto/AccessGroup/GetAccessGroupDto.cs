using APPLICATION.Dto.AccessList;

namespace APPLICATION.Dto.AccessGroup;

public class GetAccessGroupDto
{
    public int Id { get; set; }
    public string AccessGroupName { get; set; }
    // Nav
    public ICollection<GetAccessListDto> AccessLists { get; set; }
}