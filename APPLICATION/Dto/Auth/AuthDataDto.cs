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

            if (this.UserAccessGroupedBy == null)
            {
                return "[]";
            }

            if (this.UserAccessGroupedBy.Count == 0)
            {
                return "[]";
            }

            var data = "";
            var indx = 0;
            foreach (var item in this.UserAccessGroupedBy)
            {
                data += "{";
                data += $"\"id\": {item.AccessGroup.Id}, ";
                data += $"\"accessGroup\": \"{item.AccessGroup.AccessGroupName}\", ";
                data += $"\"accessLists\":";
                    
                data += "[";
                var notUnique = item.UserAccesses.Select(ua => ua.AccessList.Subject).ToList();
                List<string> subjects = [];
                foreach (var acl in notUnique)
                {
                    if (!subjects.Contains(acl))
                    {
                        subjects.Add(acl);
                    }
                }

                var subject_index = 0;
                foreach (var acl in subjects)
                {
                    data += "{";
                    data += $"\"subject\": \"{acl}\", ";
                    data += "\"actions\":";
                    data += "[";
                    var actions = item.UserAccesses.Where(ua => ua.AccessList.Subject == acl).Select(ua => ua.AccessListAction.Action).ToList();
                    foreach (var action in actions)
                    {
                        data += $"\"{action}\"";
                        if (actions.IndexOf(action) < actions.Count - 1)
                        {
                            data += ", ";
                        }
                    }
                    data += "]";
                    data += "}";
                    subject_index++;
                    if (subject_index < subjects.Count)
                    {
                        data += ", ";
                    }
                }
                data += "]";
               
                data += "}";
                ++indx;

                if (indx < this.UserAccessGroupedBy.Count)
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