using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Api.Get
{
    public static class KeyExchange
    {
        public static Networking.ResponseObject GetResponse(Security.LoginToken Token, string[] URLPath)
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
    }
}
