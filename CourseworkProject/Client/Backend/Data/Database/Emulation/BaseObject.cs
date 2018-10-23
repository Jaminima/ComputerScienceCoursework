using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Backend.Data.Database.Emulation
{
    public class BaseObject
    {
        public Newtonsoft.Json.Linq.JToken ToJson()
        {
            return Newtonsoft.Json.Linq.JToken.FromObject(this);
        }
    }
}
