using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Backend.Data.Database.Emulation
{
    public class NewUser : BaseObject
    {
        public string UserName, HashedPassword;
        public string Nickname;
        public string ImageUrl;
        public static NewUser FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<NewUser>();
        }
    }

    public class User : BaseObject
    {
        public int UserID;
        public string UserName, HashedPassword;
        public string Nickname;
        public string ImageUrl;

        public User(int InTableUserId)
        {
            UserID = InTableUserId;
        }
        public static User FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<User>();
        }
    }
}
