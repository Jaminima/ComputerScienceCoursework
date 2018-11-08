using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend
{
    public static class Init
    {
        public static Data.Database.Interaction.SQL SQLInstance = new Data.Database.Interaction.SQL("Database");
        public static void Start()
        {
            Networking.HTTPServer.Start();
        }
    }
}
