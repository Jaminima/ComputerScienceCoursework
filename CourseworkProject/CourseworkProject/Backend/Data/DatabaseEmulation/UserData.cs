using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.DatabaseEmulation
{
    public class NewUser
    {
        public string UserName, HashedPassword;
        public string Nickname;
        public string ImageUrl;
    }

    public class User
    {
        public int UserID;
        public string UserName, HashedPassword;
        public string Nickname;
        public string ImageUrl;

        public User(int InTableUserId)
        {
            UserID = InTableUserId;
        }
    }
}
