using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Data.DatabaseEmulation
{
    public class NewKeyExchange
    {
        public User User;
        public string RawPassword;
        public string ExchangeKey;
    }

    public class KeyExchange
    {
        public int ExchangeId;
        public User User;
        public string RawPassword;
        public string ExchangeKey;

        public KeyExchange(int EID)
        {
            ExchangeId = EID;
        }
    }
}
