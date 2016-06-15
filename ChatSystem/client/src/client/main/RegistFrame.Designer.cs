namespace client.main
{
    partial class RegistFrame
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
            this.label1 = new System.Windows.Forms.Label();
            this.registUsNTextBox = new System.Windows.Forms.TextBox();
            this.registPsdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.registFlagLabel = new System.Windows.Forms.Label();
            this.registBut = new System.Windows.Forms.Button();
            this.registCancleBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // registUsNTextBox
            // 
            this.registUsNTextBox.Location = new System.Drawing.Point(100, 35);
            this.registUsNTextBox.Name = "registUsNTextBox";
            this.registUsNTextBox.Size = new System.Drawing.Size(165, 21);
            this.registUsNTextBox.TabIndex = 1;
            this.registUsNTextBox.TextChanged += new System.EventHandler(this.registUsNTextBox_TextChanged);
            // 
            // registPsdTextBox
            // 
            this.registPsdTextBox.Location = new System.Drawing.Point(100, 82);
            this.registPsdTextBox.Name = "registPsdTextBox";
            this.registPsdTextBox.PasswordChar = '*';
            this.registPsdTextBox.Size = new System.Drawing.Size(165, 21);
            this.registPsdTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码：";
            // 
            // registFlagLabel
            // 
            this.registFlagLabel.AutoSize = true;
            this.registFlagLabel.Location = new System.Drawing.Point(98, 123);
            this.registFlagLabel.Name = "registFlagLabel";
            this.registFlagLabel.Size = new System.Drawing.Size(0, 12);
            this.registFlagLabel.TabIndex = 4;
            // 
            // registBut
            // 
            this.registBut.Location = new System.Drawing.Point(87, 154);
            this.registBut.Name = "registBut";
            this.registBut.Size = new System.Drawing.Size(75, 23);
            this.registBut.TabIndex = 5;
            this.registBut.Text = "注册确定";
            this.registBut.UseVisualStyleBackColor = true;
            this.registBut.Click += new System.EventHandler(this.registBut_Click);
            // 
            // registCancleBut
            // 
            this.registCancleBut.Location = new System.Drawing.Point(190, 154);
            this.registCancleBut.Name = "registCancleBut";
            this.registCancleBut.Size = new System.Drawing.Size(75, 23);
            this.registCancleBut.TabIndex = 6;
            this.registCancleBut.Text = "取消";
            this.registCancleBut.UseVisualStyleBackColor = true;
            this.registCancleBut.Click += new System.EventHandler(this.registCancleBut_Click);
            // 
            // RegistFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(311, 198);
            this.Controls.Add(this.registCancleBut);
            this.Controls.Add(this.registBut);
            this.Controls.Add(this.registFlagLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.registPsdTextBox);
            this.Controls.Add(this.registUsNTextBox);
            this.Controls.Add(this.label1);
            this.Name = "RegistFrame";
            this.Text = "注册界面";
            this.Load += new System.EventHandler(this.RegistFrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox registUsNTextBox;
        private System.Windows.Forms.TextBox registPsdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label registFlagLabel;
        private System.Windows.Forms.Button registBut;
        private System.Windows.Forms.Button registCancleBut;
    }
}