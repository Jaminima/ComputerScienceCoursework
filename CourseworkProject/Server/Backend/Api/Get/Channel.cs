using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Api.Get
{
    public static class Channel
    {
        public static Networking.ResponseObject GetChannel(Security.LoginToken Token, string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int RID;
            try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Data.Database.Emulation.Channel Channel = Data.Database.Interaction.Channel.GetChannel.FromID(RID);
            if (!((Room.IsUserInRoom(Token.User, Channel.Room)&&!Channel.ModOnly)||Room.IsUserModInRoom(Token.User,Channel.Room))) { return Networking.ResponseObject.Defaults.InsufficientPermission(); }
            Channel.Room = null;
            if (Channel == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = Channel.ToJson(); Response.Code = 200;
            Response.Message = "Succesfully retrieved Channel data";
            return Response;
        }

        public static Networking.ResponseObject GetMessages(Security.LoginToken Token, string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int CID;
            try { CID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Data.Database.Emulation.Channel Channel = Data.Database.Interaction.Channel.GetChannel.FromID(CID);
            if (Channel == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Data.Database.Emulation.Message[] Messages = Data.Database.Interaction.Message.GetMessage.RecentInChannel(Channel,20);
            if (!((Room.IsUserInRoom(Token.User, Channel.Room) && !Channel.ModOnly) || Room.IsUserModInRoom(Token.User, Channel.Room))) { return Networking.ResponseObject.Defaults.InsufficientPermission(); }
            Response.ResponseData = Newtonsoft.Json.Linq.JToken.FromObject(Messages); Response.Code = 200;
            Response.Message = "Succesfully retrieved Messages";
            return Response;
        }
    }
}
