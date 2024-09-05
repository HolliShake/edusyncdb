using APPLICATION.Dto.UserAccess;

namespace APPLICATION.Dto.User;

public class GetUserDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    /*****************************************/
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
    public string Role { get; set; }
    public ICollection<UserAccessGroupedBy> UserAccessGroupedBy { get; set; }

    public string FullName
    {
        get
        {
            if (FirstName != null && LastName != null)
            {
                return $"{LastName} {FirstName}";
            }
            
            return UserName;

        }
    }
}