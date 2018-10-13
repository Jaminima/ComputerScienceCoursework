using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.DatabaseEmulation
{
    public class NewMessage
    {
        public Channel Channel;
        public User User;
        public string Body;
        public string ImageURL;
    }

    public class Message
    {
        public int MessageId;
        public Channel Channel;
        public User User;
        public string Body;
        public string ImageURL;

        public Message(int MID)
        {
            MessageId = MID;
        }

    }
}
