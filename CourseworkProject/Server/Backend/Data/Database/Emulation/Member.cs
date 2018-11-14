using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Backend.Data.Database.Emulation
{
    public class NewMember : BaseObject
    {
        public User User;
        public Room Room;
        public Boolean IsMod;
        public static NewMember FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<NewMember>();
        }
    }

    public class Member : BaseObject
    {
        public User User;
        public Room Room;
        public Boolean IsMod;
        public int MemberID;

        public Member(int MID)
        {
            MemberID = MID;
        }
        public static Member FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<Member>();
        }
    }
}
