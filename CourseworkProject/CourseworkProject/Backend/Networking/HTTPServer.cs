using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;

namespace CourseworkProject.Backend.Networking
{
    public static class HTTPServer
    {
        static HttpListener Listener;

        public static void Start()
        {
            Listener = new HttpListener();
            Listener.Prefixes.Add("http://localhost:1234/");
            Listener.Start();
            ContextHandler(Listener);
        }

        static void ContextHandler(HttpListener Listener)
        {
            while (true) {
                HttpListenerContext Context = Listener.GetContext();
                new Thread(() => PerformRequest(Context)).Start();
            }
        }

        static void PerformRequest(HttpListenerContext Context)
        {
            ResponseObject ResponseData=new ResponseObject();
            if (Context.Request.HttpMethod == "GET") { ResponseData = Requests.GET.Handler.GetResponse(Context); }
            else if (Context.Request.HttpMethod == "POST") { ResponseData = Requests.POST.Handler.GetResponse(Context); }
            HttpListenerResponse Response = Context.Response;
            byte[] ResponseBytes = Encoding.UTF8.GetBytes(ResponseData.ToJson().ToString());
            Response.StatusCode = 200;
            Response.OutputStream.Write(ResponseBytes, 0, ResponseBytes.Length);
            Response.OutputStream.Close();
        }
    }
}
