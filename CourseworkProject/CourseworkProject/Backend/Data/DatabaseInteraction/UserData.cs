using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.DatabaseInteraction
{
    public static class UserData
    {
        public static class GetUser
        {
            public static DatabaseEmulation.User FromID(int TID)
            {
                if (UserExists(TID))
                {
                    DatabaseEmulation.User User = new DatabaseEmulation.User(TID);
                    List<String[]> UData=Init.SQLInstance.ExecuteReader(@"SELECT UserData.UserID, UserData.UserName, UserData.HashedPassword, UserData.Nickname, UserData.ImageURl
FROM UserData
WHERE (((UserData.UserID)="+TID+@"));
");
                    if (UData.Count == 0) { return null; }
                    User.UserName = UData[0][1];
                    User.HashedPassword = UData[0][2];
                    User.Nickname = UData[0][3];
                    return User;
                }
                return null;
            }

            public static DatabaseEmulation.User FromUsername(string Username)
            {
                List<string[]> UserID = Init.SQLInstance.ExecuteReader(@"SELECT UserData.UserID, UserData.UserName
FROM UserData
WHERE (((UserData.UserName)='"+Username+@"'));
");
                if (UserID.Count != 0)
                {
                    return FromID(int.Parse(UserID[0][0]));
                }
                return null;
            }

        }

        public static void SaveNewUser(DatabaseEmulation.NewUser NewUser)
        {
            Init.SQLInstance.Execute(@"INSERT INTO UserData ( UserName, HashedPassword, Nickname,ImageURl ) Values ('"+NewUser.UserName+@"','"+NewUser.HashedPassword+@"','"+NewUser.Nickname+@"','"+NewUser.ImageUrl+@"');");
        }

        public static void UpdateUser(DatabaseEmulation.User User)
        {
            if (UserExists(User.UserID))
            {
                Init.SQLInstance.Execute(@"UPDATE UserData SET UserData.UserName = '"+User.UserName+@"', UserData.HashedPassword = '"+User.HashedPassword+@"', UserData.Nickname = '"+User.Nickname+ @"', UserData.ImageURl='"+User.ImageUrl+@"'
WHERE(((UserData.UserID) = " + User.UserID+@"));
                ");
            }
        }

        public static bool UserExists(int UID)
        {
            if (GetAllUserIds().Contains(UID)) { return true; }
            return false;
        }

        public static int[] GetAllUserIds()
        {
            List<string[]> StrIds = Init.SQLInstance.ExecuteReader(@"SELECT UserData.UserID
FROM UserData;
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
