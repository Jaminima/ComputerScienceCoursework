using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.DatabaseEmulation
{
    public class NewMember
    {
        public User User;
        public Room Room;
        public Boolean IsMod;
    }

    public class Member
    {
        public User User;
        public Room Room;
        public Boolean IsMod;
        public int MemberID;

        public Member(int MID)
        {
            MemberID = MID;
        }

    }
}
