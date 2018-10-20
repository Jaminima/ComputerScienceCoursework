using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CourseworkProject.Backend.Networking.Requests.GET
{
    public static class Get
    {
        public static ResponseObject Handler(HttpListenerContext Context,string[] URLPath)
        {
            if (URLPath[3] == "channel/")
            { return Api.Get.Channel(URLPath); }
            else if (URLPath[3] == "keyexchange/")
            { return Api.Get.KeyExchange(URLPath); }
            else if (URLPath[3] == "member/")
            { return Api.Get.Member(URLPath); }
            else if (URLPath[3] == "message/")
            { return Api.Get.Message(URLPath); }
            else if (URLPath[3] == "room/")
            { return Api.Get.Room(URLPath); }
            else if (URLPath[3] == "user/")
            { return Api.Get.User(URLPath); }
            else { return ResponseObject.Defaults.PathNotFound(); }
        }
    }
}
