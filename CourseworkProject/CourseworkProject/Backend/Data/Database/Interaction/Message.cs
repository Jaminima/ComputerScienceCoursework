using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.Database.Interaction
{
    public static class Message
    {
        public static class GetMessage
        {
            public static Database.Emulation.Message FromID(int MID)
            {
                if (MessageExists(MID))
                {
                    Database.Emulation.Message Message = new Database.Emulation.Message(MID);
                    List<String[]> MData = Init.SQLInstance.ExecuteReader(@"SELECT Messages.ChannelID, Messages.UserID, Messages.Message, Messages.ImageURL, Messages.SentDateTime 
FROM Messages
WHERE (((Messages.MessageID)="+MID+@"));
");
                    if (MData.Count == 0) { return null; }
                    Message.Channel = Channel.GetChannel.FromID(int.Parse(MData[0][0]));
                    Message.User = User.GetUser.FromID(int.Parse(MData[0][1]));
                    Message.Body = MData[0][2];
                    Message.ImageURL = MData[0][3];
                    Message.SendDateTime = DateTime.Parse(MData[0][4]);
                    return Message;
                }
                return null;
            }

            public static Database.Emulation.Message FromIDChannel(int MID)
            {
                if (MessageExists(MID))
                {
                    Database.Emulation.Message Message = new Database.Emulation.Message(MID);
                    List<String[]> MData = Init.SQLInstance.ExecuteReader(@"SELECT Messages.ChannelID, Messages.UserID, Messages.Message, Messages.ImageURL, Messages.SentDateTime 
FROM Messages
WHERE (((Messages.MessageID)=" + MID + @"));
");
                    if (MData.Count == 0) { return null; }
                    Message.User = User.GetUser.FromID(int.Parse(MData[0][1]));
                    Message.Body = MData[0][2];
                    Message.ImageURL = MData[0][3];
                    Message.SendDateTime = DateTime.Parse(MData[0][4]);
                    return Message;
                }
                return null;
            }

            public static Database.Emulation.Message[] RecentInChannel(Database.Emulation.Channel Channel,int MessageCount)
            {
                List<String[]> MData = Init.SQLInstance.ExecuteReader(@"SELECT Messages.MessageID, Messages.UserID, Messages.Message, Messages.ImageURL, Messages.SentDate
FROM Messages
WHERE (((Messages.ChannelID)="+Channel.ChannelId+@"))
ORDER BY Messages.SentDate DESC;
");
                List<Database.Emulation.Message> Messages = new List<Database.Emulation.Message> { };
                if (MData.Count == 0) { return null; }
                for (int i = 0; i < MData.Count && i < MessageCount; i++)
                {
                    Database.Emulation.Message M = new Database.Emulation.Message(int.Parse(MData[i][0]));
                    M.User = User.GetUser.FromID(int.Parse(MData[i][1]));
                    M.Channel = Channel;
                    M.Body = MData[i][2];
                    M.ImageURL = MData[i][3];
                    M.SendDateTime = DateTime.Parse(MData[0][4]);
                    Messages.Add(M);
                }
                return Messages.ToArray<Database.Emulation.Message>();
            }

        }

        public static bool MessageExists(int MID)
        {
            return GetAllMessageIds().Contains(MID);
        }

        public static int[] GetAllMessageIds()
        {
            List<string[]> StrIds = Init.SQLInstance.ExecuteReader(@"SELECT Messages.MessageID
FROM Messages;
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
