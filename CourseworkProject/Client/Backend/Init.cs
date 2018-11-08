using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Backend
{
    public static class Init
    {
        public static Random Rnd = new Random();
        public static void Start()
        {
            Security.Handler.Start();
        }
    }
}
