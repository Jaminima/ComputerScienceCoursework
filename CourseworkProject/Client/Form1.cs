using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string AuthToken = Backend.Api.Login.PerformLogin("Jaminima", "Pwrd");
            Dictionary<string, string> Dic = new Dictionary<string, string> { };
            Dic.Add("AuthToken", AuthToken);
            Backend.Data.Database.Emulation.User User = Backend.Networking.WebRequests.GETRequest("api/get/user/4", Dic).ResponseData.ToObject<Backend.Data.Database.Emulation.User>();
        }
    }
}
