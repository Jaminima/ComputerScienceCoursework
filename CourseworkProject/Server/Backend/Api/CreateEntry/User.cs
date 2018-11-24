using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Backend.Api.CreateEntry
{
    public static class User
    {
        public static Networking.ResponseObject CreateUser(Security.LoginToken Token, string[] URLPath, Newtonsoft.Json.Linq.JToken StreamData)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            Data.Database.Emulation.NewUser NewUser = Data.Database.Emulation.NewUser.FromJson(Get.Channel.GetChannel(Token, URLPath).ResponseData);
            if (NewUser == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Data.Database.Interaction.User.SaveNewUser(NewUser);
            Response.Code = 200; Response.Message = "Inserted NewUser";
            return Response;
        }
    }
}
