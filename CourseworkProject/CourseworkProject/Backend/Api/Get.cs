using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Api
{
    public static class Get
    {
        public static Networking.ResponseObject Channel(string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int RID;
            try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Response.Code = 200;
            Data.Database.Emulation.Channel Channel = Data.Database.Interaction.Channel.GetChannel.FromIDRoomChannel(RID);
            if (Channel == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = Channel.ToJson();
            Response.Message = "Succesfully retrieved Channel data";
            return Response;
        }

        public static Networking.ResponseObject KeyExchange(string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int RID;
            try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Response.Code = 200;
            Data.Database.Emulation.KeyExchange KeyExchange = Data.Database.Interaction.KeyExchange.GetKeyExchange.FromID(RID);
            if (KeyExchange == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = KeyExchange.ToJson();
            Response.Message = "Succesfully retrieved KeyExchange data";
            return Response;
        }

        public static Networking.ResponseObject Member(string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int RID;
            try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Response.Code = 200;
            Data.Database.Emulation.Member Member = Data.Database.Interaction.Member.GetMember.FromIDRoomMember(RID);
            if (Member == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = Member.ToJson();
            Response.Message = "Succesfully retrieved Member data";
            return Response;
        }

        public static Networking.ResponseObject Message(string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int RID;
            try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Response.Code = 200;
            Data.Database.Emulation.Message Message = Data.Database.Interaction.Message.GetMessage.FromIDChannel(RID);
            if (Message == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = Message.ToJson();
            Response.Message = "Succesfully retrieved Message data";
            return Response;
        }

        public static Networking.ResponseObject Room(string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int RID;
            try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Response.Code = 200;
            Data.Database.Emulation.Room Room = Data.Database.Interaction.Rooms.GetRoom.FromID(RID);
            if (Room == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = Room.ToJson();
            Response.Message = "Succesfully retrieved Room data";
            return Response;
        }

        public static Networking.ResponseObject User(string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int RID;
            try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Response.Code = 200;
            Data.Database.Emulation.User User = Data.Database.Interaction.User.GetUser.FromID(RID);
            if (User == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = User.ToJson();
            Response.Message = "Succesfully retrieved User data";
            return Response;
        }

    }
}
