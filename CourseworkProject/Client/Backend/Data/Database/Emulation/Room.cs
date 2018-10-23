using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Backend.Data.Database.Emulation
{
    public class NewRoom : BaseObject
    {
        public User Owner;
        public string RoomName;
        public string ImageURL;
        public static NewRoom FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<NewRoom>();
        }
    }

    public class Room : BaseObject
    {
        public int RoomID;
        public User Owner;
        public string RoomName;
        public string ImageURL;
        public List<Member> Members = new List<Member> { };
        public List<Channel> Channels = new List<Channel> { };

        public Room(int InTableChannelId)
        {
            RoomID = InTableChannelId;
        }
        public static Room FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<Room>();
        }
    }
}
