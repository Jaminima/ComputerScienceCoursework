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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Backend.Init.Start();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            Backend.Networking.ResponseObject Response = Backend.Networking.WebRequests.POSTRequest("api/login",null,Newtonsoft.Json.Linq.JToken.Parse(@"{'UserName':'"+Txt_UserName.Text+@"','HashedPassword':'"+Backend.Security.Hasher.Hash(Txt_Password.Text)+@"'}"));
        }
    }
}
