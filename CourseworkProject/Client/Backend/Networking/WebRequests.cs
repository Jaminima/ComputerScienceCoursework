using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Client.Backend.Networking
{
    public static class WebRequests
    {
        public static ResponseObject GETRequest(string Path,Dictionary<string,string> Headers)
        {
            WebRequest Request = WebRequest.Create("http://localhost:1234/"+Path);
            Request.Method = "GET";
            if (Headers != null)
            {
                foreach (KeyValuePair<string, string> Pair in Headers)
                { Request.Headers.Add(Pair.Key, Pair.Value); }
            }
            if (Security.Handler.Encryption != null) { Request.Headers.Add("EncryptionToken", Security.Handler.Encryption.Token); }
            WebResponse Response = Request.GetResponse();
            string Data = new System.IO.StreamReader(Response.GetResponseStream()).ReadToEnd();
            return Newtonsoft.Json.Linq.JToken.Parse(Data).ToObject<ResponseObject>();
        }

        public static ResponseObject POSTRequest(string Path, Dictionary<string, string> Headers,Newtonsoft.Json.Linq.JToken Data)
        {
            WebRequest Request = WebRequest.Create("http://localhost:1234/" + Path);
            Request.Method = "POST";
            if (Headers != null)
            {
                foreach (KeyValuePair<string, string> Pair in Headers)
                { Request.Headers.Add(Pair.Key, Pair.Value); }
            }
            if (Security.Handler.Encryption != null) { Request.Headers.Add("EncryptionToken", Security.Handler.Encryption.Token); }
            if (Data != null)
            {
                byte[] bData = Encoding.UTF8.GetBytes(Data.ToString());
                Request.ContentLength = bData.Length;
                System.IO.Stream PostStream = Request.GetRequestStream();
                PostStream.Write(bData, 0, bData.Length);
                PostStream.Flush();
                PostStream.Close();
            }
            WebResponse Response = Request.GetResponse();
            string ResponseData = new System.IO.StreamReader(Response.GetResponseStream()).ReadToEnd();
            return Newtonsoft.Json.Linq.JToken.Parse(ResponseData).ToObject<ResponseObject>();
        }

    }
}
