using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Server.Backend.Api
{
    public static class Login
    {
        public static Networking.ResponseObject PerformLogin(HttpListenerContext Context, string[] URLPath, Newtonsoft.Json.Linq.JToken StreamData)
        {
            Data.Database.Emulation.User User = Data.Database.Interaction.User.GetUser.FromUsername(StreamData["UserName"].ToString());
            Networking.ResponseObject Response = new Networking.ResponseObject();
            if (User==null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            User.HashedPassword = StreamData["HashedPassword"].ToString();
            string Login = Security.Login.PerformLogin(User);
            if (Login != null)
            {
                Response.Code = 200;
                Response.Message = "Succesfully Signed In";
                User.HashedPassword = null;
                Response.ResponseData = Newtonsoft.Json.Linq.JToken.Parse(@"{'AuthToken':'" + Login + @"','User':'"+User.ToJson().ToString()+@"'}");
            }
            else
            {
                Response.Code = 500;
                Response.Message = "Invalid Password";
            }
            return Response;
        }
    }
}
