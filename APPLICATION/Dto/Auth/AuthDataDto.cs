using APPLICATION.Dto.User;

namespace APPLICATION.Dto.Auth;

public class AuthDataDto:GetUserDto
{
    public bool IsGoogle { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string AccessTokenSize 
    { 
        get 
        {
            var size = this.AccessToken.Length; // bytes
            var kb = size / 1024;
            var status = "[healthy]";

            if (kb >= 2)
            {
                status = "[good]";
            }

            else if (kb >= 4)
            {
                status = "[exceptional]";
            }
            else if (kb >= 6)
            {
                status = "[alarming]";
            }
            else if (kb >= 8)
            {
                status = "[bad_token_size]";
            }

            return $"({size}) := {kb}Kb - {status}";
        }  
    }
}