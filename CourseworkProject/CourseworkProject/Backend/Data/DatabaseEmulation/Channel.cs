using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.DatabaseEmulation
{
    public class NewChannel
    {
        public Room Room;
        public string Channelname;
        public bool ModOnly;
        public string ImageURL;
        public int PositionInRoom;
    }

    public class Channel
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

    }
}
