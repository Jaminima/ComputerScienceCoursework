using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend
{
    public static class Init
    {
        public static Data.DatabaseInteraction.SQL SQLInstance = new Data.DatabaseInteraction.SQL("Database");
    }
}
