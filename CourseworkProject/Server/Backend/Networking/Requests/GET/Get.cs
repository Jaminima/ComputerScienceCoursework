using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Server.Backend.Networking.Requests.GET
{
    public static class Get
    {
        public static ResponseObject Handler(HttpListenerContext Context,string[] URLPath)
        {
            Security.LoginToken Token = Security.Login.IsValidToken(Context);
            if (!Token.IsValid) { return ResponseObject.Defaults.AuthTokenInvalid(); }
            if (URLPath[3] == "channel/")
            { return Api.Get.Channel.GetChannel(Token, URLPath); }
            //else if (URLPath[3] == "keyexchange/")
            //{ return Api.Get.KeyExchange(Token, URLPath); }
            else if (URLPath[3] == "member/")
            { return Api.Get.Member.GetMember(Token, URLPath); }
            else if (URLPath[3] == "memberships")
            { return Api.Get.User.GetUserMemberships(Token, URLPath); }
            else if (URLPath[3] == "message/")
            { return Api.Get.Message.GetMessage(Token, URLPath); }
            else if (URLPath[3] == "recentmessages/")
            { return Api.Get.Channel.GetMessages(Token, URLPath); }
            else if (URLPath[3] == "room/")
            { return Api.Get.Room.GetRoom(Token, URLPath); }
            else if (URLPath[3] == "user/")
            { return Api.Get.User.GetUser(Token, URLPath); }
            else { return ResponseObject.Defaults.PathNotFound(); }
        }
    }
}
