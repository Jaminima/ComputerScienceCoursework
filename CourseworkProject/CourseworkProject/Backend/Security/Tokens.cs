using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Security
{
    public static class Tokens
    {
        public static Objects.Token CreateTokenLogin(Data.Database.Emulation.User user)
        {
            return new Objects.Token(CreateToken());
        }

        static Random Rnd=new Random();
        static string CreateToken()
        {
            string sToken = "";
            for (int i = 0; i < 32; i++) { sToken += Char.ConvertFromUtf32(Rnd.Next(33, 127)); }
            return sToken;
        }
    }
}
