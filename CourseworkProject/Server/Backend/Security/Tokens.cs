using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Backend.Security
{
    public static class Tokens
    {
        static Random Rnd=new Random();
        public static string CreateToken()
        {
            string sToken = "";
            for (int i = 0; i < 32; i++) {
                sToken += Char.ConvertFromUtf32(Rnd.Next(40, 92));
            }
            sToken.Replace("\\", "/");
            return sToken;
        }
    }
}
