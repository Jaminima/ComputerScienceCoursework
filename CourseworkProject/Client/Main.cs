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
        Backend.Data.Database.Emulation.Room Room;
        Backend.Data.Database.Emulation.Channel Channel;

        public Main()
        {
            InitializeComponent();
        }

        static List<Backend.Data.Database.Emulation.Member> Memberships;
        private void Main_Load(object sender, EventArgs e)
        {
            List<TableLayoutPanel> Tables = new List<TableLayoutPanel> { Tbl_Messages,Table_Channels,Table_Rooms };
            UpdateRooms();
            CurrentRoom = Memberships[0].Room.RoomID;
            Room = Memberships[0].Room;
            CurrentChannel = Memberships[0].Room.Channels[0].ChannelId;
            Channel = Room.Channels[0];
            UpdateChannels();
            UpdateMessages();
            foreach (TableLayoutPanel Control in Tables)
            {
                TableLayoutPanel Panel = (TableLayoutPanel)Control;
                Panel.HorizontalScroll.Maximum = 0;
                Panel.AutoScroll = false;
                Panel.VerticalScroll.Visible = false;
                Panel.AutoScroll = true;
            }
        }

        public void UpdateRooms()
        {
            Table_Channels.Controls.Clear();
            Tbl_Messages.Controls.Clear();
            Table_Rooms.Controls.Clear();
            Memberships = Backend.Api.Get.Memberships();
            for (int i = 0; i < Memberships.Count; i++)
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
            UpdateChannels();
        }

        public void UpdateChannels()
        {
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
            UpdateMessages();
        }

        public void UpdateMessages()
        {
            List<Backend.Data.Database.Emulation.Message> Messages = Backend.Api.Get.RecentMessages(CurrentChannel);
            Messages.Reverse();
            Tbl_Messages.Controls.Clear();
            int i = 0;
            foreach (Backend.Data.Database.Emulation.Message Message in Messages)
            {
                PictureBox Picture = new PictureBox();
                Picture.Name = "UserImage" + Message.MessageId + "-" + Message.User.UserID;
                Picture.Height = 30; Picture.Width = 30; Picture.SizeMode = PictureBoxSizeMode.StretchImage;
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
                BodyLabel.Width = 450;
                BodyLabel.Height = 30;
                //BodyLabel.Height = 20;
                Tbl_Messages.Controls.Add(BodyLabel, 2, i);

                i++;
            }
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            Backend.Networking.WebRequests.POSTRequest("api/createentry/message/"+CurrentChannel,null,Newtonsoft.Json.Linq.JToken.Parse(@"{'Body':'"+Txt_Message.Text+@"'}"));
            Txt_Message.Text = "";
            UpdateMessages();
        }

        private void Tmr_RefreshMessages_Tick(object sender, EventArgs e)
        {
            UpdateMessages();
        }

        private void Txt_Message_TextChanged(object sender, EventArgs e)
        {
            Lbl_WordCount.Text = Txt_Message.Text.Length.ToString()+"/100";
        }
    }
}
