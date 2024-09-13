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

            if (this.UserAccessGroupDetails == null)
            {
                return "[]";
            }

            if (this.UserAccessGroupDetails.Count == 0)
            {
                return "[]";
            }

            var data = "";
            List<string> uniqueAccessGroup = [];
            foreach (var item in UserAccessGroupDetails)
            {
                var name = item.AccessGroupAction.AccessGroup.AccessGroupName;
                if (!uniqueAccessGroup.Contains(name))
                {
                    uniqueAccessGroup.Add(name);
                }
            }
            var index_i = 0;
            foreach (var name in uniqueAccessGroup)
            {
                data += "{";
                data += $"\"accessGroup\": \"{name}\", ";
                data += "\"actions\":";
                data += "[";
            
                var access = UserAccessGroupDetails.Where(uagd => uagd.AccessGroupAction.AccessGroup.AccessGroupName == name).Select(uagd => uagd.AccessGroupAction.Action).ToList();
                var index_j = 0;
                foreach (var item in access)
                {
                    data += $"\"{item}\"";
                    if (index_j < access.Count - 1)
                    {
                        data += ", ";
                    }
                    ++index_j;
                }
                data += "]";
                data += "}";
                if (index_i < uniqueAccessGroup.Count - 1)
                {
                    data += ", ";
                }
                ++index_i;
            }
            return "[" + data + "]";
        }

        set 
        {
            this.AccessListStringMain = value;
        }
    }

    public string AccessListStringRaw { get; set; }
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