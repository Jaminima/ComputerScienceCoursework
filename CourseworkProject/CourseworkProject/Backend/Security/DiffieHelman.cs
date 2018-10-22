using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CourseworkProject.Backend.Security
{
    public static class DiffieHelman
    {
        static Random Rnd = new Random();
        public static Networking.ResponseObject PerformDiffiehelman(HttpListenerContext Context)
        {
            Networking.ResponseObject ResponseObject=new Networking.ResponseObject();
            string Address = Context.Request.RemoteEndPoint.ToString() + Context.Request.LocalEndPoint.ToString();
            int B=Rnd.Next();
            int G = int.Parse(Context.Request.Headers["g"]);
            int N = int.Parse(Context.Request.Headers["n"]);
            int GA = int.Parse(Context.Request.Headers["ga"]);
            string Token=Encryption.CreateToken(GA.ToString());
            ResponseObject.Code = 200; ResponseObject.Message = "Succesfully performed DiffieHelman";
            ResponseObject.Encrypted = false;
            ResponseObject.ResponseData = Newtonsoft.Json.Linq.JToken.FromObject(new DiffieHelmanResponse(Token, (G ^ B) % N));
            return ResponseObject;
        }
    }

    public class DiffieHelmanResponse
    {
        public string Token;
        public int gb;
        public DiffieHelmanResponse(string lToken,int lgb)
        {
            gb = lgb;Token = lToken;
        }
    }
}
