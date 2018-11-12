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
        int CurrentRoom = -1, CurrentChannel=-1;
        public Main()
        {
            InitializeComponent();
        }

        static List<Backend.Data.Database.Emulation.Member> Memberships;
        private void Main_Load(object sender, EventArgs e)
        {
            UpdateRooms();
            CurrentRoom = 0;
            UpdateChannels();
            CurrentChannel = Memberships[0].Room.Channels[0].ChannelId;
        }

        public void UpdateRooms()
        {
            Memberships = Backend.Api.Get.Memberships();
            for (int i = 0; i < Memberships.Count && i < 12; i++)
            {
                PictureBox RoomIcon = new PictureBox();
                RoomIcon.Name = "RoomIcon" + Memberships[i].Room.RoomID;
                RoomIcon.Width = 50; RoomIcon.Height = 50;
                RoomIcon.BackColor = Color.Green;
                RoomIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                RoomIcon.Image = Image.FromStream(Backend.Networking.WebRequests.GETRequest(Memberships[i].Room.ImageURL));
                this.Table_Rooms.Controls.Add(RoomIcon, 0, i);
            }
        }

        public void UpdateChannels()
        {
            Backend.Data.Database.Emulation.Room CRoom = Memberships[CurrentRoom].Room;
            for (int i = 0; i < CRoom.Channels.Count; i++)
            {
                Label Text = new Label();
                Text.Text = CRoom.Channels[i].Channelname;
                Text.ForeColor = Color.Red;
                Text.BackColor = Color.Green;
                Text.Location = new Point(0, 0);
                Text.Height = 20;
                Text.Name = "Channel" + CRoom.Channels[i].ChannelId;
                Text.BringToFront();
                Text.Click += UpdateMessages;
                this.Table_Channels.Controls.Add(Text, 0, i);
            }
        }

        public void UpdateMessages(object sender, EventArgs e)
        {
            List<Backend.Data.Database.Emulation.Message> Messages = Backend.Api.Get.RecentMessages(CurrentChannel);
            Tbl_Messages.Controls.Clear();
            foreach (Backend.Data.Database.Emulation.Message Message in Messages)
            {
                PictureBox Picture = new PictureBox();
                Picture.Name = "UserImage" + Message.MessageId + "-" + Message.User.UserID;
                Picture.Height = 50;Picture.Width = 50;Picture.SizeMode = PictureBoxSizeMode.StretchImage;
                Picture.Image = Image.FromStream(Backend.Networking.WebRequests.GETRequest(Message.User.ImageUrl));
                Label UserLabel = new Label();
                Label BodyLabel = new Label();
            }
        }

        private void Txt_Message_TextChanged(object sender, EventArgs e)
        {
            Lbl_WordCount.Text = Txt_Message.Text.Length.ToString();
        }
    }
}
