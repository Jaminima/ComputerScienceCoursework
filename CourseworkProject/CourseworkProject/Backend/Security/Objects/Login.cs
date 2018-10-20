using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Security.Objects
{
    public class Login:Data.Database.Emulation.BaseObject
    {
        public Data.Database.Emulation.User User;
        public Token Token;
        public Login(Data.Database.Emulation.User lUser,Token lToken)
        {
            Token = lToken;User = lUser;
        }
    }
}
