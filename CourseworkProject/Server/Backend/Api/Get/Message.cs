using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Backend.Api.Get
{
    public static class Message
    {
        public static Networking.ResponseObject GetMessage(Security.LoginToken Token, string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int RID;
            try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Response.Code = 200;
            Data.Database.Emulation.Message Message = Data.Database.Interaction.Message.GetMessage.FromID(RID);
            if (!((Room.IsUserInRoom(Token.User, Message.Channel.Room) && !Message.Channel.ModOnly) || Room.IsUserModInRoom(Token.User, Message.Channel.Room))) { return Networking.ResponseObject.Defaults.InsufficientPermission(); }
            Message.Channel = null;
            if (Message == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = Message.ToJson();
            Response.Message = "Succesfully retrieved Message data";
            return Response;
        }
    }
}
