using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkProject.Backend.Security.Objects
{
    public class Token : Data.Database.Emulation.BaseObject
    {
        public string Text;
        public DateTime CreationDateTime;

        public Token(string lToken)
        {
            Text = lToken;
            CreationDateTime = DateTime.Now;
        }
    }
}
