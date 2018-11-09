using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Client.Backend.Security
{
    public static class DiffieHelman
    {
        public static EncryptionObject PerformDiffieHelman()
        {
            int G=GetSmallPrime(), N=Init.Rnd.Next(G+1,200), A=Init.Rnd.Next(G,N);
            BigInteger GA = BigInteger.Remainder(BigInteger.Pow(G, A), N);
            Dictionary<string,string> Headers = new Dictionary<string, string> { };
            Headers.Add("g", G.ToString()); Headers.Add("n", N.ToString()); Headers.Add("ga", GA.ToString());
            Networking.ResponseObject Response = Networking.WebRequests.GETRequest("api/diffiehelman",Headers);
            BigInteger GB = BigInteger.Parse(Response.ResponseData["gb"].ToString());
            BigInteger GABA = BigInteger.Remainder(BigInteger.Pow(GB, A), N);
            EncryptionObject Obj = new EncryptionObject();
            Obj.Token = Response.ResponseData["Token"].ToString();
            Obj.Key = GABA;
            return Obj;
        }

        static int[] SmallPrimes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
        static int GetSmallPrime()
        {
            return SmallPrimes[Init.Rnd.Next(0, SmallPrimes.Length)];
        }

    }
}
