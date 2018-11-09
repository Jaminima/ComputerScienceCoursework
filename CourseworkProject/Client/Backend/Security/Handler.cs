using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Client.Backend.Security
{
    public static class Handler
    {
        public static EncryptionObject Encryption;
        public static string LoginToken;
        public static Newtonsoft.Json.Linq.JToken ThisUser;

        public static void Start()
        {
            Encryption = DiffieHelman.PerformDiffieHelman();
        }
    }

    public class EncryptionObject
    {
        public BigInteger Key;
        public string Token;
    }
}
