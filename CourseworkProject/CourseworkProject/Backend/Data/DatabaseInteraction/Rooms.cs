using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.DatabaseInteraction
{
    public static class Rooms
    {
        public static class GetRoom
        {
            public static DatabaseEmulation.Room FromName(string RoomName)
            {
                List<String[]> RID = Init.SQLInstance.ExecuteReader(@"SELECT Rooms.RoomID, Rooms.RoomName
FROM Rooms
WHERE (((Rooms.RoomName)='"+RoomName+@"'));
");
                if (RID.Count != 0) { return FromID(int.Parse(RID[0][0])); }
                return null;
            }

            public static DatabaseEmulation.Room FromID(int RID)
            {
                if (RoomExists(RID))
                {
                    DatabaseEmulation.Room Room = new DatabaseEmulation.Room(RID);
                    List<String[]> RData = Init.SQLInstance.ExecuteReader(@"SELECT Rooms.RoomID, Rooms.OwnerID, Rooms.RoomName, Rooms.ImageURL
FROM Rooms
WHERE (((Rooms.RoomID)="+RID+@"));
");
                    if (RData.Count == 0) { return null; }
                    Room.Owner = UserData.GetUser.FromID(int.Parse(RData[0][1]));
                    Room.RoomName = RData[0][2];
                    Room.ImageURL = RData[0][3];
                    foreach(int MID in Member.GetAllMemberIdsInRoom(RID))
                    {
                        Room.Members.Add(Member.GetMember.FromIDRoomMember(MID));
                    }
                    foreach (int CID in Channel.GetChannelIdsInRoom(RID))
                    {
                        Room.Channels.Add(Channel.GetChannel.FromIDRoomChannel(CID));
                    }
                    return Room;
                }
                return null;
            }
        }

        public static void DeleteRoom(DatabaseEmulation.Room Room)
        {
            Init.SQLInstance.Execute(@"DELETE Rooms.RoomID
FROM Rooms
WHERE (((Rooms.RoomID)="+Room.RoomID+@"));
");
        }

        public static void InsertRoom(DatabaseEmulation.NewRoom NewRoom)
        {
            Init.SQLInstance.Execute(@"INSERT INTO Rooms (OwnerID, RoomName, ImageURL) VALUES ("+NewRoom.Owner.UserID+@",'"+NewRoom.RoomName+@"','"+NewRoom.ImageURL+@"');");
        }

        public static void UpdateRoom(DatabaseEmulation.Room Room)
        {
            if (RoomExists(Room.RoomID))
            {
                Init.SQLInstance.Execute(@"UPDATE Rooms SET Rooms.OwnerID = "+Room.Owner.UserID+@", Rooms.RoomName = '"+Room.RoomName+@"', Rooms.ImageURL = '"+Room.ImageURL+@"'
WHERE(((Rooms.RoomID) = "+Room.RoomID+@"));
                ");
            }
        }

        public static bool RoomExists(int RID)
        {
            return GetAllRoomIds().Contains(RID);
        }

        public static int[] GetAllRoomIds()
        {
            List<string[]> StrIds = Init.SQLInstance.ExecuteReader(@"SELECT Rooms.RoomID
FROM Rooms;
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
