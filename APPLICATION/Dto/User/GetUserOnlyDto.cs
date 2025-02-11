namespace APPLICATION.Dto.User;

public class GetUserOnlyDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string ProfileImage { get; set; }
    /*****************************************/
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {
        get
        {
            return $"{this.LastName}, {this.FirstName}";
        }
    }
    public int? ReferenceId { get; set; }
}