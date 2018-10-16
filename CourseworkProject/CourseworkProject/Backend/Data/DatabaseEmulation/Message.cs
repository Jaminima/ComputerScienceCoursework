using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.DatabaseEmulation
{
    public class NewMessage : BaseObject
    {
        public Channel Channel;
        public User User;
        public string Body;
        public string ImageURL;
        public DateTime SendDateTime;
        public static NewMessage FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<NewMessage>();
        }
    }

    public class Message : BaseObject
    {
        public int MessageId;
        public Channel Channel;
        public User User;
        public string Body;
        public string ImageURL;
        public DateTime SendDateTime;

        public Message(int MID)
        {
            MessageId = MID;
        }
        public static Message FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<Message>();
        }
    }
}
