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
    public partial class RegistFrame : Form,Frame
    {//登陆操作映射类
        private RegistView registView;
        private static int port = 8888;
        public RegistFrame()
        {
            InitializeComponent();
            this.registView = new RegistView(this);
        }
        private void registBut_Click(object sender, EventArgs e)
        {

            if (check(registUsNTextBox.Text, registPsdTextBox.Text)) {
                registView.regist(registUsNTextBox.Text, registPsdTextBox.Text);
                    }
            else {
                changeDis("输入不能为空，注册失败");
            }
        }
        private bool check(string usn,String psd)
        {
            if (usn==null|| psd == null) {
                return false;
            }
            return true;
        }

        private void registCancleBut_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void changeDis(string content)
        {
            if (content.CompareTo("registOk") == 0)
            {
                this.registFlagLabel.Text = "注册成功";
            }
            else {
                this.registFlagLabel.Text = content;
            }
        }

        public void warnMsg(string content)
        {
            throw new NotImplementedException();
        }

        private void RegistFrame_Load(object sender, EventArgs e)
        {

        }

        private void registUsNTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
