using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Backend.Api
{
    public static class Get
    {
        public static Data.Database.Emulation.User User(int UID)
        {
            Networking.ResponseObject UserResponse = Networking.WebRequests.GETRequest("/api/get/user/"+UID, null);
            if (UserResponse.Code == 200) { return UserResponse.ResponseData.ToObject<Data.Database.Emulation.User>(); }
            return null;
        }

        public static List<Data.Database.Emulation.Member> Memberships()
        {
            Networking.ResponseObject UserResponse = Networking.WebRequests.GETRequest("/api/get/memberships", null);
            if (UserResponse.Code == 200) { return UserResponse.ResponseData.ToObject<List<Data.Database.Emulation.Member>>(); }
            return null;
        }

        public static List<Data.Database.Emulation.Message> RecentMessages(int CID)
        {
            Networking.ResponseObject UserResponse = Networking.WebRequests.GETRequest("/api/get/recentmessages/"+CID, null);
            if (UserResponse.Code == 200) { return UserResponse.ResponseData.ToObject<List<Data.Database.Emulation.Message>>(); }
            return null;
        }

    }
}
