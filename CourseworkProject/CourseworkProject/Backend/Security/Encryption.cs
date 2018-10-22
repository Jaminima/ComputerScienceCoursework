using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CourseworkProject.Backend.Security
{
    public static class Encryption
    {
        static Dictionary<string, string> TokenKeys = new Dictionary<string, string> { };

        public static string CreateToken(string GA)
        {
            string Token = Tokens.CreateToken();
            TokenKeys.Add(Token, GA);
            return Token;
        }
        
        public static Networking.ResponseObject PerformEncryption(Networking.ResponseObject ResponseObject, HttpListenerContext Context)
        {
            if (ResponseObject.Encrypted&&ResponseObject.ResponseData!=null)
            {
                ResponseObject.ResponseData = Newtonsoft.Json.Linq.JToken.Parse(Encrypt(ResponseObject.ResponseData.ToString(), Context.Request.Headers["EncryptionToken"]));
            }
            return ResponseObject;
        }
        static string[] HeadersToIgnore = new string[] { "EncryptionToken","Accept","","Host","User-Agent"};
        public static HttpListenerContext PerformDecryption(HttpListenerContext Context)
        {
            if (Context.Request.Headers.AllKeys.Contains("EncryptionToken"))
            {
                string EncToken = Context.Request.Headers["EncryptionToken"];
                if (!TokenKeys.ContainsKey(EncToken)) { return Context; }
                for (int i = 0; i < Context.Request.Headers.Count; i++)
                {
                    if (!HeadersToIgnore.Contains(Context.Request.Headers.AllKeys[i]))
                    {
                        Context.Request.Headers[Context.Request.Headers.AllKeys[i]] = Decrypt(Context.Request.Headers[Context.Request.Headers.AllKeys[i]], EncToken);
                    }
                }
            }
            return Context;
        }
        public static string PerformDecryption(string Data, HttpListenerContext Context)
        {
            if (Context.Request.Headers.AllKeys.Contains("EncryptionToken"))
            {
                Data = Decrypt(Data, Context.Request.Headers["EncryptionToken"]);
            }
            return Data;
        }

        public static string Encrypt(string Raw,string Token)
        {
            string Key = TokenKeys[Token];
            string Enc = "";
            return Enc;
        }

        public static string Decrypt(string Enc, string Token)
        {
            string Key = TokenKeys[Token];
            string Raw = "";
            return Raw;
        }

    }
}
