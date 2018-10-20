using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CourseworkProject.Backend.Networking.Requests.POST
{
    public static class Handler
    {
        public static ResponseObject GetResponse(HttpListenerContext Context)
        {
            ResponseObject Response = new ResponseObject();
            string[] URLPath = Context.Request.Url.Segments;
            string StreamString = new System.IO.StreamReader(Context.Request.InputStream).ReadToEnd();
            Newtonsoft.Json.Linq.JToken StreamData = Newtonsoft.Json.Linq.JToken.Parse(StreamString);
            if (URLPath[1] == "api/")
            {
                if (URLPath[2] == "login")
                { return Api.Login.PerformLogin(Context, URLPath,StreamData); }
                else { return ResponseObject.Defaults.PathNotFound(); }
            }
            return Response;
        }
    }
}
