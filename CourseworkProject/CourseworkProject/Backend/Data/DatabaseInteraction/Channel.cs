using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.DatabaseInteraction
{
    public static class Channel
    {
        public static class GetChannel
        {
            public static DatabaseEmulation.Channel FromID(int CID)
            {
                if (ChannelExists(CID))
                {
                    DatabaseEmulation.Channel Channel = new DatabaseEmulation.Channel(CID);
                    List<String[]> CData = Init.SQLInstance.ExecuteReader(@"SELECT Channels.ChannelID, Channels.RoomID, Channels.Channelname, Channels.ModeratorOnly, Channels.ImageURL, Channels.PositionInRoom
FROM Channels
WHERE (((Channels.ChannelID)="+CID+@"));
");
                    if (CData.Count == 0) { return null; }
                    Channel.Room = Rooms.GetRoom.FromID(int.Parse(CData[0][1]));
                    Channel.Channelname = CData[0][2];
                    Channel.ModOnly = CData[0][3] == "True";
                    Channel.ImageURL = CData[0][4];
                    Channel.PositionInRoom = int.Parse(CData[0][5]);
                    return Channel;
                }
                return null;
            }

            public static DatabaseEmulation.Channel FromIDRoomChannel(int CID)
            {
                if (ChannelExists(CID))
                {
                    DatabaseEmulation.Channel Channel = new DatabaseEmulation.Channel(CID);
                    List<String[]> CData = Init.SQLInstance.ExecuteReader(@"SELECT Channels.ChannelID, Channels.RoomID, Channels.Channelname, Channels.ModeratorOnly, Channels.ImageURL, Channels.PositionInRoom
FROM Channels
WHERE (((Channels.ChannelID)=" + CID + @"));
");
                    if (CData.Count == 0) { return null; }
                    Channel.Channelname = CData[0][2];
                    Channel.ModOnly = CData[0][3] == "True";
                    Channel.ImageURL = CData[0][4];
                    Channel.PositionInRoom = int.Parse(CData[0][5]);
                    return Channel;
                }
                return null;
            }
        }

        public static void DeleteChannel(DatabaseEmulation.Channel Channel)
        {
            Init.SQLInstance.Execute(@"DELETE Channels.ChannelID
FROM Channels
WHERE (((Channels.ChannelID)="+Channel.ChannelId+@"));
");
        }

        public static void InsertChannel(DatabaseEmulation.NewChannel NewChannel)
        {
            Init.SQLInstance.Execute(@"INSERT INTO Channels (Channelname,ModeratorOnly,ImageURL,PositionInRoom) VALUES ('"+NewChannel.Channelname+@"',"+NewChannel.ModOnly+@",'"+NewChannel.ImageURL+@"',"+NewChannel.PositionInRoom+@");");
        }

        public static void UpdateChannel(DatabaseEmulation.Channel Channel)
        {
            if (ChannelExists(Channel.Room.RoomID, Channel.ChannelId))
            {
                Init.SQLInstance.Execute(@"UPDATE Channels SET Channels.RoomID = 2, Channels.Channelname = '"+Channel.Channelname+@"', Channels.ModeratorOnly = "+Channel.ModOnly+", Channels.ImageURL = '"+Channel.ImageURL+@"', Channels.PositionInRoom = "+Channel.PositionInRoom+@"
WHERE(((Channels.ChannelID) = "+Channel.ChannelId+@"));
                ");
            }
        }

        public static bool ChannelExists(int RID,int CID)
        {
            return GetChannelIdsInRoom(RID).Contains(CID);
        }
        public static bool ChannelExists(int CID)
        {
            return GetChannelIds().Contains(CID);
        }

        public static int[] GetChannelIdsInRoom(int RID)
        {
            List<String[]> StrIds = Init.SQLInstance.ExecuteReader(@"SELECT Channels.ChannelID, Channels.RoomID
FROM Channels
WHERE (((Channels.RoomID)="+RID+@"));
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

        public static int[] GetChannelIds()
        {
            List<String[]> StrIds = Init.SQLInstance.ExecuteReader(@"SELECT Channels.ChannelID, Channels.RoomID
FROM Channels;
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
