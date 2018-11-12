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
            CurrentChannel = Memberships[0].Room.Channels[0].ChannelId;
        }

        public void UpdateRooms()
        {
            Table_Channels.Controls.Clear();
            Tbl_Messages.Controls.Clear();
            Table_Rooms.Controls.Clear();
            Memberships = Backend.Api.Get.Memberships();
            for (int i = 0; i < Memberships.Count && i < 12; i++)
            {
                PictureBox RoomIcon = new PictureBox();
                RoomIcon.Name = "RoomIcon" + Memberships[i].Room.RoomID;
                RoomIcon.Width = 50; RoomIcon.Height = 50;
                RoomIcon.BackColor = Color.Green;
                RoomIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                RoomIcon.Click += UpdateChannels;
                if (Memberships[i].Room.ImageURL != null)
                {RoomIcon.Image = Image.FromStream(Backend.Networking.WebRequests.GETRequest(Memberships[i].Room.ImageURL));}
                else
                { RoomIcon.BackColor = Color.Gray; }
                this.Table_Rooms.Controls.Add(RoomIcon, 0, i);
            }
        }

        public void UpdateChannels(object sender, EventArgs e)
        {
            CurrentRoom=int.Parse(((Control)sender).Name.Remove(0,8));
            Table_Channels.Controls.Clear();
            Tbl_Messages.Controls.Clear();
            Backend.Data.Database.Emulation.Room CRoom = Backend.Api.Get.Room(CurrentRoom);
            for (int i = 0; i < CRoom.Channels.Count; i++)
            {
                Label Text = new Label();
                Text.Text = CRoom.Channels[i].Channelname;
                Text.ForeColor = Color.White;
                //Text.Height = 20;
                Text.Name = "Channel" + CRoom.Channels[i].ChannelId;
                Text.Click += UpdateMessages;
                this.Table_Channels.Controls.Add(Text, 0, i);
            }
        }

        public void UpdateMessages(object sender, EventArgs e)
        {
            CurrentChannel = int.Parse(((Control)sender).Name.Remove(0, 7));
            List<Backend.Data.Database.Emulation.Message> Messages = Backend.Api.Get.RecentMessages(CurrentChannel);
            Messages.Reverse();
            Tbl_Messages.Controls.Clear();
            int i = 0;
            foreach (Backend.Data.Database.Emulation.Message Message in Messages)
            {
                PictureBox Picture = new PictureBox();
                Picture.Name = "UserImage" + Message.MessageId + "-" + Message.User.UserID;
                Picture.Height = 30;Picture.Width = 30;Picture.SizeMode = PictureBoxSizeMode.StretchImage;
                if (Message.User.ImageUrl != null)
                { Picture.Image = Image.FromStream(Backend.Networking.WebRequests.GETRequest(Message.User.ImageUrl)); }
                Tbl_Messages.Controls.Add(Picture, 0, i);

                Label UserLabel = new Label();
                UserLabel.Text = Message.User.UserName;
                UserLabel.Name = "UserName" + Message.MessageId + "-" + Message.User.UserID;
                UserLabel.ForeColor = Color.White;
                //UserLabel.Height = 20;
                Tbl_Messages.Controls.Add(UserLabel, 1, i);

                Label BodyLabel = new Label();
                BodyLabel.Text = Message.Body;
                BodyLabel.Name = "Body" + Message.MessageId + "-" + Message.User.UserID;
                BodyLabel.ForeColor = Color.Wheat;
                //BodyLabel.Height = 20;
                Tbl_Messages.Controls.Add(BodyLabel, 2, i);

                i++;
            }
        }

        private void Txt_Message_TextChanged(object sender, EventArgs e)
        {
            Lbl_WordCount.Text = Txt_Message.Text.Length.ToString();
        }
    }
}
