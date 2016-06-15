namespace client.main
{
    partial class SelfMainFrame
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("在线好友");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("离线好友");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("群聊");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("所有在线");
            this.chatTree = new System.Windows.Forms.TreeView();
            this.selfImfs = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatTree
            // 
            this.chatTree.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chatTree.Location = new System.Drawing.Point(-4, 60);
            this.chatTree.Name = "chatTree";
            treeNode1.Name = "onlineFrds";
            treeNode1.Text = "在线好友";
            treeNode2.Name = "exitFrds";
            treeNode2.Text = "离线好友";
            treeNode3.Name = "节点4";
            treeNode3.Text = "群聊";
            treeNode4.Name = "节点0";
            treeNode4.Text = "所有在线";
            this.chatTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.chatTree.Size = new System.Drawing.Size(359, 269);
            this.chatTree.TabIndex = 0;
            this.chatTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // selfImfs
            // 
            this.selfImfs.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.selfImfs.Location = new System.Drawing.Point(-4, 2);
            this.selfImfs.Multiline = true;
            this.selfImfs.Name = "selfImfs";
            this.selfImfs.Size = new System.Drawing.Size(359, 60);
            this.selfImfs.TabIndex = 1;
            this.selfImfs.Text = "个人信息";
            this.selfImfs.TextChanged += new System.EventHandler(this.selfImfs_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(394, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "关闭连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChatFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(530, 325);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selfImfs);
            this.Controls.Add(this.chatTree);
            this.Name = "ChatFrame";
            this.Text = "个人界面";
            this.Load += new System.EventHandler(this.ChatFrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView chatTree;
        private System.Windows.Forms.TextBox selfImfs;
        private System.Windows.Forms.Button button1;
    }
}