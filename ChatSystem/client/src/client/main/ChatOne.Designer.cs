using System;
using client.view;

namespace client.main
{
    partial class ChatOne
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
            this.recieveTextBox = new System.Windows.Forms.TextBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.forClientlabel = new System.Windows.Forms.Label();
            this.addFriendBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recieveTextBox
            // 
            this.recieveTextBox.Location = new System.Drawing.Point(-3, 33);
            this.recieveTextBox.Multiline = true;
            this.recieveTextBox.Name = "recieveTextBox";
            this.recieveTextBox.Size = new System.Drawing.Size(418, 182);
            this.recieveTextBox.TabIndex = 0;
            this.recieveTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(-3, 235);
            this.sendTextBox.Multiline = true;
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(337, 58);
            this.sendTextBox.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(340, 235);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 58);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "发送";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // forClientlabel
            // 
            this.forClientlabel.AutoSize = true;
            this.forClientlabel.Location = new System.Drawing.Point(13, 15);
            this.forClientlabel.Name = "forClientlabel";
            this.forClientlabel.Size = new System.Drawing.Size(65, 12);
            this.forClientlabel.TabIndex = 3;
            this.forClientlabel.Text = "对面用户：";
            // 
            // addFriendBut
            // 
            this.addFriendBut.Location = new System.Drawing.Point(267, 4);
            this.addFriendBut.Name = "addFriendBut";
            this.addFriendBut.Size = new System.Drawing.Size(75, 23);
            this.addFriendBut.TabIndex = 4;
            this.addFriendBut.Text = "加为好友";
            this.addFriendBut.UseVisualStyleBackColor = true;
            this.addFriendBut.Click += new System.EventHandler(this.addFriendBut_Click);
            // 
            // ChatOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 305);
            this.Controls.Add(this.addFriendBut);
            this.Controls.Add(this.forClientlabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.recieveTextBox);
            this.Name = "ChatOne";
            this.Text = "与好友聊天";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox recieveTextBox;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label forClientlabel;
        private System.Windows.Forms.Button addFriendBut;
       
    
    }
}