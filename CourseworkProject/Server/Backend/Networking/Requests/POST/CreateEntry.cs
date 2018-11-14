using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Server.Backend.Networking.Requests.POST
{
    public static class CreateEntry
    {
        public static ResponseObject Handler(Security.LoginToken Token, string[] URLPath, Newtonsoft.Json.Linq.JToken StreamData)
        {
            if (URLPath[3] == "message/")
            { return Api.CreateEntry.Message.SaveMessage(Token,URLPath,StreamData); }
            else { return ResponseObject.Defaults.PathNotFound(); }
        }
    }
}
