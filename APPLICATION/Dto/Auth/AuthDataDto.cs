using APPLICATION.Dto.User;

namespace APPLICATION.Dto.Auth;

public class AuthDataDto : GetUserDto
{
    public bool IsGoogle { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }

    private string AccessListStringMain { get; set; } = null;
    public string AccessListString 
    {
        get 
        {
            if (this.AccessListStringMain != null)
            {
                return this.AccessListStringMain;
            }

            if (this.AccessList == null)
            {
                return "[]";
            }

            if (this.AccessList.Count == 0)
            {
                return "[]";
            }

            var data = "";
            var indx = 0;
            foreach (var item in this.AccessList)
            {
                data += "{";
                data += $"\"subject\": \"{item.AccessList.Subject}\", \"action\": \"{item.AccessListAction.Action}\"";
                data += "}";
                ++indx;

                if (indx < this.AccessList.Count)
                {
                    data += ", ";
                }
            }

            return "[" + data + "]";
        }

        set 
        {
            this.AccessListStringMain = value;
        }
    }
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