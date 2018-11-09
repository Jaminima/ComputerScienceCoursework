using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Backend.Api
{
    public static class Login
    {
        public static bool PerformLogin(string UserName,string HashedPassword)
        {
            Backend.Networking.ResponseObject Resp = Backend.Networking.WebRequests.POSTRequest("api/login", null, Newtonsoft.Json.Linq.JToken.Parse("{\"UserName\": \""+UserName+"\",\"HashedPassword\": \""+HashedPassword+"\"}"));
            if (Resp.Code != 200) { return false; }
            Backend.Security.Handler.LoginToken = Resp.ResponseData["AuthToken"].ToString();
            Backend.Security.Handler.ThisUser = Resp.ResponseData["User"];
            return true;
        }
    }
}
