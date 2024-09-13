using APPLICATION.Dto.AccessGroupAction;
namespace APPLICATION.Dto.AccessGroup;

public class GetAccessGroupDto
{
    public int Id { get; set; }
    public string AccessGroupName { get; set; }
    // Nav
    public ICollection<GetAccessGroupActionDto> AccessGroupActions { get; set; }
}