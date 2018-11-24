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
    public partial class SignUp : Form
    {
        public SignUp()
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

        private void Btn_AutoSignUp_Click(object sender, EventArgs e)
        {

        }

        private void Btn_SignUp_Click(object sender, EventArgs e)
        {

        }

        bool PerformSignUp(string UserName,string Password)
        {
            return false;
        }

    }
}
