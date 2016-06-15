using System;

namespace client.main
{
    partial class LoginFrame
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
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usnText = new System.Windows.Forms.TextBox();
            this.pswdText = new System.Windows.Forms.TextBox();
            this.loginBut = new System.Windows.Forms.Button();
            this.registBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginFlagLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usnText
            // 
            this.usnText.Location = new System.Drawing.Point(79, 72);
            this.usnText.Name = "usnText";
            this.usnText.Size = new System.Drawing.Size(192, 21);
            this.usnText.TabIndex = 0;
            // 
            // pswdText
            // 
            this.pswdText.Location = new System.Drawing.Point(79, 111);
            this.pswdText.Name = "pswdText";
            this.pswdText.PasswordChar = '*';
            this.pswdText.Size = new System.Drawing.Size(192, 21);
            this.pswdText.TabIndex = 1;
            this.pswdText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // loginBut
            // 
            this.loginBut.Location = new System.Drawing.Point(79, 181);
            this.loginBut.Name = "loginBut";
            this.loginBut.Size = new System.Drawing.Size(75, 23);
            this.loginBut.TabIndex = 2;
            this.loginBut.Text = "登陆";
            this.loginBut.UseVisualStyleBackColor = true;
            this.loginBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // registBut
            // 
            this.registBut.Location = new System.Drawing.Point(196, 181);
            this.registBut.Name = "registBut";
            this.registBut.Size = new System.Drawing.Size(75, 23);
            this.registBut.TabIndex = 3;
            this.registBut.Text = "注册";
            this.registBut.UseVisualStyleBackColor = true;
            this.registBut.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码：";
            // 
            // loginFlagLabel
            // 
            this.loginFlagLabel.AutoSize = true;
            this.loginFlagLabel.Location = new System.Drawing.Point(79, 152);
            this.loginFlagLabel.Name = "loginFlagLabel";
            this.loginFlagLabel.Size = new System.Drawing.Size(0, 12);
            this.loginFlagLabel.TabIndex = 6;
            // 
            // LoginFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(349, 243);
            this.Controls.Add(this.loginFlagLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registBut);
            this.Controls.Add(this.loginBut);
            this.Controls.Add(this.pswdText);
            this.Controls.Add(this.usnText);
            this.Name = "LoginFrame";
            this.Text = "登陆界面";
            this.Load += new System.EventHandler(this.LoginFrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        #endregion

        private System.Windows.Forms.TextBox usnText;
        private System.Windows.Forms.TextBox pswdText;
        private System.Windows.Forms.Button loginBut;
        private System.Windows.Forms.Button registBut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label loginFlagLabel;
    }
}