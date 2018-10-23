using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Backend.Api
{
    public static class Login
    {
        public static string PerformLogin(string UserName,string HashedPassword)
        {
            Backend.Networking.ResponseObject Resp = Backend.Networking.WebRequests.POSTRequest("api/login", null, Newtonsoft.Json.Linq.JToken.Parse("{\"UserName\": \""+UserName+"\",\"HashedPassword\": \""+HashedPassword+"\"}"));
            if (Resp.Code != 200) { return null; }
            return Resp.ResponseData["AuthToken"].ToString();
        }
    }
}
