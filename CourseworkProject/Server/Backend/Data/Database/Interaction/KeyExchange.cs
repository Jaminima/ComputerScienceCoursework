using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Backend.Data.Database.Interaction
{
    public static class KeyExchange
    {
        public static class GetKeyExchange
        {
            public static Database.Emulation.KeyExchange FromID(int KID)
            {
                if (KeyExchangeExists(KID))
                {
                    Database.Emulation.KeyExchange Key = new Database.Emulation.KeyExchange(KID);
                    List<String[]> KData = Init.SQLInstance.ExecuteReader(@"SELECT KeyExchange.ExchangeID, KeyExchange.UserID, KeyExchange.RawPassword, KeyExchange.ExchangeKey, KeyExchange.DateTime
FROM KeyExchange
WHERE (((KeyExchange.ExchangeID)="+KID+@"));
");
                    if (KData.Count == 0) { return null; }
                    Key.User = User.GetUser.FromID(int.Parse(KData[0][1]));
                    Key.RawPassword = KData[0][2];
                    Key.ExchangeKey = KData[0][3];
                    Key.DateTime = DateTime.Parse(KData[0][4]);
                    return Key;
                }
                return null;
            }
        }

        public static void InsertKeyExchange(Database.Emulation.NewKeyExchange NewKeyExchange)
        {
            if (!UserAlreadyHasKeyExchange(NewKeyExchange.User.UserID))
            {
                Init.SQLInstance.Execute(@"INSERT INTO KeyExchange (UserID,RawPassword,ExchangeKey,KeyExchange,DateTime) VALUES (" + NewKeyExchange.User.UserID + @",'" + NewKeyExchange.RawPassword + @"','" + NewKeyExchange.ExchangeKey + @"','" + NewKeyExchange.DateTime.ToString() + @"');");
            }
        }

        public static void UpdateKeyExchange(Database.Emulation.KeyExchange KeyExchange)
        {
            if (KeyExchangeExists(KeyExchange.ExchangeId))
            {
                Init.SQLInstance.Execute(@"UPDATE KeyExchange SET KeyExchange.UserID = "+KeyExchange.User.UserID+@", KeyExchange.RawPassword = '"+KeyExchange.RawPassword+@"', KeyExchange.ExchangeKey = '"+KeyExchange.ExchangeKey+@"' KeyExchange.DateTime = '"+KeyExchange.DateTime+@"'
WHERE(((KeyExchange.ExchangeID) = "+KeyExchange.ExchangeId+@"));
                ");
            }
        }

        public static bool KeyExchangeExists(int KID)
        {
            return GetKeyExchangeIds().Contains(KID);
        }
        public static bool UserAlreadyHasKeyExchange(int UID)
        {
            List<String[]> StrIds = Init.SQLInstance.ExecuteReader(@"Select KeyExchange.ExchangeID 
FROM KeyExchange
WHERE KeyExchange.UserID = "+UID+@";
");
            return StrIds.Count == 1;
        }

        public static int[] GetKeyExchangeIds()
        {
            List<String[]> StrIds = Init.SQLInstance.ExecuteReader(@"SELECT KeyExchange.ExchangeID
FROM KeyExchange;
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
