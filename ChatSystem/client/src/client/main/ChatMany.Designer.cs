namespace client.main
{
    partial class ChatMany
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("群聊在线人数");
            this.chatMannyTree = new System.Windows.Forms.TreeView();
            this.recieveTextBox = new System.Windows.Forms.TextBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatMannyTree
            // 
            this.chatMannyTree.Location = new System.Drawing.Point(2, -1);
            this.chatMannyTree.Name = "chatMannyTree";
            treeNode1.Name = "m";
            treeNode1.Text = "群聊在线人数";
            this.chatMannyTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.chatMannyTree.Size = new System.Drawing.Size(121, 260);
            this.chatMannyTree.TabIndex = 0;
            this.chatMannyTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.chatMannyTree_AfterSelect);
            // 
            // recieveTextBox
            // 
            this.recieveTextBox.Location = new System.Drawing.Point(139, 12);
            this.recieveTextBox.Multiline = true;
            this.recieveTextBox.Name = "recieveTextBox";
            this.recieveTextBox.Size = new System.Drawing.Size(444, 173);
            this.recieveTextBox.TabIndex = 1;
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(139, 204);
            this.sendTextBox.Multiline = true;
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(278, 45);
            this.sendTextBox.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(442, 204);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(106, 45);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "发送";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ChatMany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 261);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.recieveTextBox);
            this.Controls.Add(this.chatMannyTree);
            this.Name = "ChatMany";
            this.Text = "群聊";
            this.Load += new System.EventHandler(this.ChatMany_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView chatMannyTree;
        private string v;
        private System.Windows.Forms.TextBox recieveTextBox;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button sendButton;
    }
}