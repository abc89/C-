using client.msg;
using client.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.main
{
    public partial class ChatOne : Form,Frame
    {
        private String myName;
        private String forName;
        private ChatView view;
        private String selfMsg;
        //自定义委托类型，委托签名（解释见PPT）与该委托将要绑定的方法签名应保持一致（本例为不带参数的方法）
        //委托类型应在本处而不能在方法里面定义
        public delegate void ReadSptEventHandler();
 //       private Frame fFrame;

        public ChatOne(String myname,string forname)
        {
            this.myName = myname;
            this.forName = forname;
            InitializeComponent();
            view = new ChatView(this);
            view.oneChat(forname);
            this.forClientlabel.Text = "聊天对象:" + forname;
        }
        public void changeDis(string content)
        {
       
            ReadSptEventHandler rse = new ReadSptEventHandler(show);
            this.selfMsg = content;
            recieveTextBox.Invoke(rse);
        }
        public void show()
        {
           // fFrame.changeDis(selfMsg);

            recieveTextBox.AppendText("\r\n  " + forName+" 对你说:");
            Msg msg = new Msg(selfMsg);
            recieveTextBox.AppendText("\r\n  "+ msg.getMsgContent());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String content = this.sendTextBox.Text;
            view.sendOneContent(content);
            recieveTextBox.AppendText("\r\n\t\t\t\t\t\t" + myName+"你自己：\r\n\t\t\t\t\t\t" + content);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addFriendBut_Click(object sender, EventArgs e)
        {
            view.addFriend(forName);
        }

        public void warnMsg(string content)
        {
            ReadSptEventHandler rse = new ReadSptEventHandler(showWarn);
            this.selfMsg = content;
            recieveTextBox.Invoke(rse);
        }
        public void showWarn()
        {
            MessageBox.Show(selfMsg); ;
        }

    }
}
