using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Server.Backend.Api.CreateEntry
{
    public static class Message
    {
        public static Networking.ResponseObject SaveMessage(Security.LoginToken Token, string[] URLPath, Newtonsoft.Json.Linq.JToken StreamData)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            Data.Database.Emulation.Channel Channel = Data.Database.Emulation.Channel.FromJson(Get.Channel.GetChannel(Token, URLPath).ResponseData);
            if (Channel == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Data.Database.Emulation.NewMessage NewMessage = new Data.Database.Emulation.NewMessage();
            NewMessage.Body = StreamData["Body"].ToString();
            NewMessage.SendDateTime = DateTime.Now;
            NewMessage.User = Token.User;
            NewMessage.Channel = Channel;

            Data.Database.Interaction.Message.InsertMessage(NewMessage);

            Response.Code = 200; Response.Message = "Inserted Message";
            return Response;
        }
    }
}
