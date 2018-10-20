using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CourseworkProject.Backend.Networking.Requests.GET
{
    public static class Handler
    {
        public static ResponseObject GetResponse(HttpListenerContext Context)
        {
            ResponseObject Response = new ResponseObject();
            string[] URLPath = Context.Request.Url.Segments;
            if (URLPath[1] == "api/")
            {
                if (URLPath[2] == "get/")
                { return Get.Handler(Context,URLPath); }
                else { return ResponseObject.Defaults.PathNotFound(); }
            }
            else { return ResponseObject.Defaults.PathNotFound(); }
        }
    }
}
