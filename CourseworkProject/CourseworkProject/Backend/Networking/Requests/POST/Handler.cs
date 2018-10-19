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
            return Response;
        }
    }
}
