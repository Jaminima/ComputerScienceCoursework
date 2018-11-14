using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Backend.Api.Get
{
    public static class Room
    {
        public static Networking.ResponseObject GetRoom(Security.LoginToken Token, string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int RID;
            try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Response.Code = 200;
            Data.Database.Emulation.Room Room = Data.Database.Interaction.Rooms.GetRoom.FromID(RID);
            if (!IsUserInRoom(Token.User, Room)) { return Networking.ResponseObject.Defaults.InsufficientPermission(); }
            if (Room == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = Room.ToJson();
            Response.Message = "Succesfully retrieved Room data";
            return Response;
        }

        public static bool IsUserInRoom(Data.Database.Emulation.User User, Data.Database.Emulation.Room Room)
        {
            foreach (Data.Database.Emulation.Member Member in Room.Members) { if (Member.User.UserID == User.UserID) { return true; } }
            return false;
        }
        public static bool IsUserModInRoom(Data.Database.Emulation.User User, Data.Database.Emulation.Room Room)
        {
            foreach (Data.Database.Emulation.Member Member in Room.Members) { if (Member.User.UserID == User.UserID) { return Member.IsMod; } }
            return false;
        }
    }
}
