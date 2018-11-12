using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Numerics;

namespace CourseworkProject.Backend.Security
{
    public static class DiffieHelman
    {
        static Random Rnd = new Random();
        public static Networking.ResponseObject PerformDiffiehelman(HttpListenerContext Context)
        {
            Networking.ResponseObject ResponseObject=new Networking.ResponseObject();
            string Address = Context.Request.RemoteEndPoint.ToString() + Context.Request.LocalEndPoint.ToString();
            int G = int.Parse(Context.Request.Headers["g"]);
            int N = int.Parse(Context.Request.Headers["n"]);
            int B = Rnd.Next(G,N);
            BigInteger GA = BigInteger.Parse(Context.Request.Headers["ga"]);
            BigInteger GABA = BigInteger.Remainder(BigInteger.Pow(GA, B),N);
            string Token=Encryption.CreateToken(GABA);
            ResponseObject.Code = 200; ResponseObject.Message = "Succesfully performed DiffieHelman";
            ResponseObject.Encrypted = false;
            ResponseObject.ResponseData = Newtonsoft.Json.Linq.JToken.FromObject(new DiffieHelmanResponse(Token,BigInteger.Remainder(BigInteger.Pow(G,B),N)));
            return ResponseObject;
        }
    }

    public class DiffieHelmanResponse
    {
        public string Token;
        public BigInteger gb;
        public DiffieHelmanResponse(string lToken,BigInteger lgb)
        {
            gb = lgb;Token = lToken;
        }
    }
}
