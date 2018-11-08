using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Api.Get
{
    public static class User
    {
        public static Networking.ResponseObject GetUser(Security.LoginToken Token, string[] URLPath)
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

        public static Networking.ResponseObject GetUserMemberships(Security.LoginToken Token, string[] URLPath)
        {
            Networking.ResponseObject Response = new Networking.ResponseObject();
            //int RID;
            //try { RID = int.Parse(URLPath[4]); } catch { return Networking.ResponseObject.Defaults.InvalidParameter(); }
            Response.Code = 200;
            List<Data.Database.Emulation.Member> Memberships = Data.Database.Interaction.Member.GetMember.UserMemberships(Token.User.UserID);
            if (Memberships == null) { return Networking.ResponseObject.Defaults.ItemDoesntExist(); }
            Response.ResponseData = Newtonsoft.Json.Linq.JToken.FromObject(Memberships);
            Response.Message = "Succesfully retrieved Memberships";
            return Response;
        }
    }
}
