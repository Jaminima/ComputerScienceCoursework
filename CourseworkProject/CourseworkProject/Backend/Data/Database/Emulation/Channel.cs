using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.Database.Emulation
{
    public class NewChannel : BaseObject
    {
        public Room Room;
        public string Channelname;
        public bool ModOnly;
        public string ImageURL;
        public int PositionInRoom;
        public static NewChannel FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<NewChannel>();
        }
    }

    public class Channel : BaseObject
    {
        public int ChannelId;
        public Room Room;
        public string Channelname;
        public bool ModOnly;
        public string ImageURL;
        public int PositionInRoom;

        public Channel(int CID)
        {
            ChannelId = CID;
        }
        public static Channel FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<Channel>();
        }
    }
}
