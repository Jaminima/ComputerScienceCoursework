using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //    Backend.Data.DatabaseEmulation.NewUser NewUser = new Backend.Data.DatabaseEmulation.NewUser();
            //    NewUser.UserName = "Jaminima";NewUser.Nickname = "Jcc";NewUser.HashedPassword = "Pwrd";
            //    Backend.Data.DatabaseInteraction.UserData.SaveNewUser(NewUser);

            //Backend.Data.DatabaseEmulation.NewRoom NewRoom = new Backend.Data.DatabaseEmulation.NewRoom();
            //NewRoom.RoomName = "MyRoom"; NewRoom.Owner = Backend.Data.DatabaseInteraction.UserData.GetUser.FromUsername("Jaminima");
            //Backend.Data.DatabaseInteraction.Rooms.InsertRoom(NewRoom);

            //Backend.Data.DatabaseEmulation.NewMember NewMember = new Backend.Data.DatabaseEmulation.NewMember();
            //NewMember.User= Backend.Data.DatabaseInteraction.UserData.GetUser.FromUsername("Jaminima");
            //NewMember.Room = Backend.Data.DatabaseInteraction.Rooms.GetRoom.FromName("MyRoom");
            //NewMember.IsMod = false;
            //Backend.Data.DatabaseInteraction.Member.InsertMember(NewMember);

            Backend.Data.DatabaseEmulation.Member Member = Backend.Data.DatabaseInteraction.Member.GetMember.FromID(2);
            Member.IsMod = true;
            Backend.Data.DatabaseInteraction.Member.UpdateMember(Member);

        }
    }
}
