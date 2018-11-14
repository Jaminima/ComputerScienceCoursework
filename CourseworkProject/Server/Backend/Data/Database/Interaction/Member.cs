using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Backend.Data.Database.Interaction
{
    public static class Member
    {
        public static class GetMember
        {
            public static Database.Emulation.Member FromID(int MID)
            {
                if (MemberExists(MID))
                {
                    Database.Emulation.Member Member = new Database.Emulation.Member(MID);
                    List<String[]> MData = Init.SQLInstance.ExecuteReader(@"SELECT Memberships.MembershipID, Memberships.UserID, Memberships.RoomID, Memberships.IsModerator
FROM (UserData INNER JOIN Rooms ON UserData.UserID = Rooms.OwnerID) INNER JOIN Memberships ON (UserData.UserID = Memberships.UserID) AND (Rooms.RoomID = Memberships.RoomID)
WHERE (((Memberships.MembershipID)="+MID+@"));
");
                    if (MData.Count == 0) { return null; }
                    Member.User = User.GetUser.FromID(int.Parse(MData[0][1]));
                    Member.Room = Rooms.GetRoom.FromID(int.Parse(MData[0][2]));
                    Member.IsMod = MData[0][3]=="True";
                    return Member;
                }
                return null;
            }

            public static Database.Emulation.Member FromIDRoomMember(int MID)
            {
                if (MemberExists(MID))
                {
                    Database.Emulation.Member Member = new Database.Emulation.Member(MID);
                    List<String[]> MData = Init.SQLInstance.ExecuteReader(@"SELECT Memberships.MembershipID, Memberships.UserID, Memberships.RoomID, Memberships.IsModerator
FROM (UserData INNER JOIN Rooms ON UserData.UserID = Rooms.OwnerID) INNER JOIN Memberships ON (UserData.UserID = Memberships.UserID) AND (Rooms.RoomID = Memberships.RoomID)
WHERE (((Memberships.MembershipID)=" + MID + @"));
");
                    if (MData.Count == 0) { return null; }
                    Member.User = User.GetUser.FromID(int.Parse(MData[0][1]));
                    Member.IsMod = MData[0][3] == "True";
                    return Member;
                }
                return null;
            }

            public static List<Database.Emulation.Member> UserMemberships(int UID)
            {
                List<String[]> MData= Init.SQLInstance.ExecuteReader(@"SELECT Memberships.MembershipID, Memberships.UserID, Memberships.RoomID, Memberships.IsModerator
FROM (UserData INNER JOIN Rooms ON UserData.UserID = Rooms.OwnerID) INNER JOIN Memberships ON (UserData.UserID = Memberships.UserID) AND (Rooms.RoomID = Memberships.RoomID)
WHERE (((Memberships.UserID)=" + UID + @"));
");
                List<Database.Emulation.Member> Memberships = new List<Emulation.Member> { };
                if (MData.Count == 0) { return null; }
                foreach (String[] Item in MData)
                {
                    Database.Emulation.Member M = new Emulation.Member(int.Parse(Item[0]));
                    M.User = null;/*User.GetUser.FromID(int.Parse(Item[1]));*/
                    M.Room = Rooms.GetRoom.FromID(int.Parse(Item[2]));
                    M.IsMod = Item[3] == "True";
                    Memberships.Add(M);
                }
                return Memberships;
            }

        }

        public static void DeleteMember(Database.Emulation.Member Member)
        {
            if (Member.Room.Owner.UserID != Member.User.UserID)
            {
                Init.SQLInstance.Execute(@"DELETE Memberships.MembershipID
FROM Memberships
WHERE (((Memberships.MembershipID)=" + Member.MemberID + @"));
");
            }
            else { Rooms.DeleteRoom(Member.Room); }
        }

        public static void InsertMember(Database.Emulation.NewMember NewMember)
        {
            Init.SQLInstance.Execute(@"INSERT INTO Memberships (UserID, RoomID, IsModerator) VALUES ("+NewMember.User.UserID+@","+NewMember.Room.RoomID+@","+NewMember.IsMod+@");");
        }

        public static void UpdateMember(Database.Emulation.Member Member)
        {
            if (MemberExists(Member.MemberID))
            {
                Init.SQLInstance.Execute(@"UPDATE Memberships SET Memberships.UserID = "+Member.User.UserID+@", Memberships.RoomID = "+Member.Room.RoomID+@", Memberships.IsModerator = "+Member.IsMod.ToString()+@"
WHERE (((Memberships.MembershipID)="+Member.MemberID+@"));
");
            }
        }
        
        public static bool MemberExists(int MID)
        {
            if (GetAllMemberIds().Contains(MID)) { return true; }
            return false;
        }

        public static bool RoomMemberExists(int UID,int RID)
        {
            if (GetAllMemberIdsInRoom(RID).Contains(UID)) { return true; }
            return false;
        }

        public static int[] GetAllMemberIdsInRoom(int RID)
        {
            List<string[]> StrIds = Init.SQLInstance.ExecuteReader(@"SELECT Memberships.MembershipID, Memberships.UserID, Memberships.RoomID, Memberships.IsModerator
FROM (UserData INNER JOIN Rooms ON UserData.UserID = Rooms.OwnerID) INNER JOIN Memberships ON (UserData.UserID = Memberships.UserID) AND (Rooms.RoomID = Memberships.RoomID)
WHERE (((Memberships.RoomID)="+RID+@"));
");
            if (StrIds.Count != 0)
            {
                List<int> IntIds = new List<int> { };
                foreach (string[] Id in StrIds)
                {
                    IntIds.Add(int.Parse(Id[0]));
                }
                return IntIds.ToArray<int>();
            }
            return new int[] { };
        }

        public static int[] GetAllMemberIds()
        {
            List<string[]> StrIds = Init.SQLInstance.ExecuteReader(@"SELECT Memberships.MembershipID, Memberships.UserID, Memberships.RoomID, Memberships.IsModerator
FROM (UserData INNER JOIN Rooms ON UserData.UserID = Rooms.OwnerID) INNER JOIN Memberships ON (UserData.UserID = Memberships.UserID) AND (Rooms.RoomID = Memberships.RoomID);
");
            if (StrIds.Count != 0)
            {
                List<int> IntIds = new List<int> { };
                foreach (string[] Id in StrIds)
                {
                    IntIds.Add(int.Parse(Id[0]));
                }
                return IntIds.ToArray<int>();
            }
            return new int[] { };
        }

    }
}
