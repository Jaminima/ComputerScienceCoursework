namespace Client
{
    partial class SignUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Txt_UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_SignUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_URL = new System.Windows.Forms.TextBox();
            this.Btn_AutoSignUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Txt_UserName
            // 
            this.Txt_UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_UserName.Location = new System.Drawing.Point(86, 10);
            this.Txt_UserName.Name = "Txt_UserName";
            this.Txt_UserName.Size = new System.Drawing.Size(144, 20);
            this.Txt_UserName.TabIndex = 0;
            this.Txt_UserName.Text = "Jaminima";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // Txt_Password
            // 
            this.Txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Password.Location = new System.Drawing.Point(86, 36);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(144, 20);
            this.Txt_Password.TabIndex = 2;
            this.Txt_Password.Text = "Pwrd";
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Cancel.Location = new System.Drawing.Point(12, 108);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(68, 23);
            this.Btn_Cancel.TabIndex = 4;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_SignUp
            // 
            this.Btn_SignUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_SignUp.Location = new System.Drawing.Point(168, 108);
            this.Btn_SignUp.Name = "Btn_SignUp";
            this.Btn_SignUp.Size = new System.Drawing.Size(62, 23);
            this.Btn_SignUp.TabIndex = 5;
            this.Btn_SignUp.Text = "SignUp";
            this.Btn_SignUp.UseVisualStyleBackColor = true;
            this.Btn_SignUp.Click += new System.EventHandler(this.Btn_SignUp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image URL";
            // 
            // Txt_URL
            // 
            this.Txt_URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_URL.Location = new System.Drawing.Point(86, 61);
            this.Txt_URL.Name = "Txt_URL";
            this.Txt_URL.Size = new System.Drawing.Size(144, 20);
            this.Txt_URL.TabIndex = 6;
            this.Txt_URL.Text = "Pwrd";
            // 
            // Btn_AutoSignUp
            // 
            this.Btn_AutoSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_AutoSignUp.Location = new System.Drawing.Point(86, 108);
            this.Btn_AutoSignUp.Name = "Btn_AutoSignUp";
            this.Btn_AutoSignUp.Size = new System.Drawing.Size(76, 23);
            this.Btn_AutoSignUp.TabIndex = 8;
            this.Btn_AutoSignUp.Text = "Auto SignUp";
            this.Btn_AutoSignUp.UseVisualStyleBackColor = true;
            this.Btn_AutoSignUp.Click += new System.EventHandler(this.Btn_AutoSignUp_Click);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(242, 143);
            this.Controls.Add(this.Btn_AutoSignUp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_URL);
            this.Controls.Add(this.Btn_SignUp);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_UserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignUp";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_SignUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_URL;
        private System.Windows.Forms.Button Btn_AutoSignUp;
    }
}

