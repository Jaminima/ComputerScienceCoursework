using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CourseworkProject.Backend.Networking.Requests.POST
{
    public static class Login
    {
        public static ResponseObject PerformLogin(HttpListenerContext Context, string[] URLPath,Newtonsoft.Json.Linq.JToken StreamData)
        {
            Data.Database.Emulation.User User = Data.Database.Emulation.User.FromJson(StreamData);
            ResponseObject Response = new ResponseObject();
            if (!Data.Database.Interaction.User.UserExists(User.UserID)) { return ResponseObject.Defaults.ItemDoesntExist(); }
            string Login = Security.Login.PerformLogin(User);
            if (Login != null)
            {
                Response.Code = 200;
                Response.Message = "Succesfully Signed In";
                Response.ResponseData = "{\"AuthToken\":\""+Login+"\"}";
            }else
            {
                Response.Code = 500;
                Response.Message = "Invalid Password";
            }
            return Response;
        }
    }
}
