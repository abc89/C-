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
    public partial class ChatMany : Form,Frame
    {
        private String myName;
        private ChatView view;
        private String selfMsg;
        //自定义委托类型，委托签名（解释见PPT）与该委托将要绑定的方法签名应保持一致（本例为不带参数的方法）
        //委托类型应在本处而不能在方法里面定义
        public delegate void ReadSptEventHandler();
        public ChatMany(string v)
        {
            InitializeComponent();
            if (view==null) {
                this.view = new ChatView(this);
                view.configMannyChat();
                this.v = v;
            }
        }
        public void changeDis(string content)
        {
            ReadSptEventHandler rse = new ReadSptEventHandler(show);
            this.selfMsg = content;
            recieveTextBox.Invoke(rse);
        }
        public void show()
        {
            recieveTextBox.AppendText("\r\n" + selfMsg);
        }

        private void chatMannyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void ChatMany_Load(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            String msg = sendTextBox.Text;
            view.sendMannyContent(msg);
        }

        public void warnMsg(string content)
        {
            throw new NotImplementedException();
        }
    }
}
