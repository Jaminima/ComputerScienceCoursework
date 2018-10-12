using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.DatabaseEmulation
{
    public class NewRoom
    {
        public User Owner;
        public string RoomName;
        public string ImageURL;
    }

    public class Room
    {
        public int RoomID;
        public User Owner;
        public string RoomName;
        public string ImageURL;
        public List<Member> Members = new List<Member> { };

        public Room(int InTableChannelId)
        {
            RoomID = InTableChannelId;
        }
    }
}
