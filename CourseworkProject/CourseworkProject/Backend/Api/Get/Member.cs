using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Api.Get
{
    public static class Member
    {
        public static Networking.ResponseObject GetMember(Security.LoginToken Token, string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            int RID;
            try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Response.Code = 200;
            Data.Database.Emulation.Member Member = Data.Database.Interaction.Member.GetMember.FromID(RID);
            if (!Room.IsUserInRoom(Token.User, Member.Room)) { return Networking.ResponseObject.Defaults.InsufficientPermission(); }
            Member.Room = null;
            if (Member == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = Member.ToJson();
            Response.Message = "Succesfully retrieved Member data";
            return Response;
        }
    }
}
