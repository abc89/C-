using client.data;
using client.logs;
using client.msg;
using client.operate;
using client.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.main
{
    public partial class ChatFrame : Form,Frame
    {
        private MainView view;
        private String name;
        private String selfMsg;
        //自定义委托类型，委托签名（解释见PPT）与该委托将要绑定的方法签名应保持一致（本例为不带参数的方法）
        //委托类型应在本处而不能在方法里面定义
        public delegate void ReadSptEventHandler();
        public ChatFrame()
        {
            InitializeComponent();
            if (view==null) {
                this.view = new MainView(this);
                this.selfImfs.Text = "用户：" + view.getMyName();
            }
        }
  
        public void changeDis(string content)
        {
            ReadSptEventHandler rse = new ReadSptEventHandler(show);
            this.selfMsg = content;
            this.Invoke(rse);
            ClientLogs.log(content);
        }
        /*   public void show()
           {
               Msg msg = new Msg(selfMsg);
               if (msg.getMsgType().CompareTo(Msg.CONTROL) == 0)
               {
                   if (msg.getControlType().CompareTo(Msg.ContentType.GETMYFRIENDS) == 0)
                   {
                       if (PersonDataSet.contain(msg.getMsgContent()))
                       {
                           TreeNode node = this.chatTree.Nodes[0];
                           TreeNode newNode = new TreeNode();
                           newNode.Text = "@" + msg.getMsgContent();
                           node.Nodes.Add(newNode);
                       }
                       else {
                           TreeNode node = this.chatTree.Nodes[1];
                           TreeNode newNode = new TreeNode();
                           newNode.Text = "离线" + msg.getMsgContent();
                           node.Nodes.Add(newNode);

                       }
                   }
                   else if (msg.getControlType().CompareTo(Msg.ContentType.NEWCLIENT) == 0)
                   {
                       TreeNode node = this.chatTree.Nodes[3];
                       TreeNode newNode = new TreeNode();
                       newNode.Text = "@" + msg.getName();
                       node.Nodes.Add(newNode);
                   }
               }
           }*/
        public void show()
        {
            if (selfMsg.CompareTo("fzgx") == 0)
            {
                List<String> ofs = MyFriends.getOnlineNames();

                TreeNode node = this.chatTree.Nodes[0];
                node.Nodes.Clear();
                foreach (String name in ofs) {

                        TreeNode newNode = new TreeNode();
                        newNode.Text = "@" + name;
                        node.Nodes.Add(newNode);
                }

                List<String> nfss = MyFriends.getNolinkNames();

                 node = this.chatTree.Nodes[1];
                node.Nodes.Clear();
                foreach (String name in nfss)
                {

                    TreeNode newNode = new TreeNode();
                    newNode.Text = "@" + name;
                    node.Nodes.Add(newNode);
                }
                List<String> allofs = PersonDataSet.getNames();

                 node = this.chatTree.Nodes[3];
                node.Nodes.Clear();
                foreach (String name in allofs)
                {

                    TreeNode newNode = new TreeNode();
                    newNode.Text = "@" + name;
                    node.Nodes.Add(newNode);
                }
                
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
             TreeNode selectNode = this.chatTree.SelectedNode;
             String name = selectNode.Text;
            if (name.IndexOf("@") != -1) {
                view.oneChat(name.Substring(1));
            } else if (name.IndexOf("群聊")!=-1) {
                view.mannyChat();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void selfImfs_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            view.close();
            this.Dispose();
        }

        private void ChatFrame_Load(object sender, EventArgs e)
        {
           
        }

        public void warnMsg(string content)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            view.test();
        }
    }
}
