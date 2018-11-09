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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        static List<Backend.Data.Database.Emulation.Member> Memberships;
        private void Main_Load(object sender, EventArgs e)
        {
            Memberships = Backend.Api.Get.Memberships();
            for (int i= 0;i<Memberships.Count&&i<12;i++)
            {
                PictureBox RoomIcon = new PictureBox();
                RoomIcon.Name="RoomIcon"+i;
                RoomIcon.Width = 50; RoomIcon.Height = 50;
                RoomIcon.BackColor = Color.Red;
                this.Table_Rooms.Controls.Add(RoomIcon,0,i);
            }
        }
    }
}
