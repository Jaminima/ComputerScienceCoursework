using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Api.Get
{
    public static class User
    {
        public static Networking.ResponseObject GetResponse(Security.LoginToken Token, string[] URLPath)
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
