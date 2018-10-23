using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Backend.Data.Database.Emulation
{
    public class NewKeyExchange : BaseObject
    {
        public User User;
        public string RawPassword;
        public string ExchangeKey;
        public DateTime DateTime;
        public static NewKeyExchange FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<NewKeyExchange>();
        }
    }

    public class KeyExchange : BaseObject
    {
        public int ExchangeId;
        public User User;
        public string RawPassword;
        public string ExchangeKey;
        public DateTime DateTime;

        public KeyExchange(int EID)
        {
            ExchangeId = EID;
        }
        public static KeyExchange FromJson(Newtonsoft.Json.Linq.JToken Json)
        {
            return Json.ToObject<KeyExchange>();
        }
    }
}
