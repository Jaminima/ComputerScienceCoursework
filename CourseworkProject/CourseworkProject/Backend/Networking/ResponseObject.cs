using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Networking
{
    public class ResponseObject
    {
        public int Code=100;
        public string Message="Invalid Request Method";
        public Newtonsoft.Json.Linq.JToken ResponseData;
        public Newtonsoft.Json.Linq.JToken ToJson()
        {
            return Newtonsoft.Json.Linq.JToken.FromObject(this);
        }
        public class Defaults
        {
            public static ResponseObject PathNotFound()
            {
                ResponseObject Response = new ResponseObject();
                Response.Code = 404; Response.Message = "That path goes to nothing";
                return Response;
            }
            public static ResponseObject InvalidParameter()
            {
                ResponseObject Response = new ResponseObject();
                Response.Code = 101; Response.Message = "Invalid Parameter";
                return Response;
            }
            public static ResponseObject ItemDoesntExist()
            {
                ResponseObject Response = new ResponseObject();
                Response.Code = 405; Response.Message = "An item with that ID does not exist";
                return Response;
            }
        }

    }
}
