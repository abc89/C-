using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.view;
using client.logs;

namespace client.main
{
    public partial class LoginFrame : Form,Frame
    {
        //登陆操作映射类
        private LoginView loginView;
        private static int port = 8888;
        public LoginFrame()
        {
            InitializeComponent();
                this.loginView = new LoginView(this);
            new LogFrame().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RegistFrame().Show();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String password = this.pswdText.Text;
            String userName = this.usnText.Text;
            loginView.login(userName,password);
          
        }
   

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void changeDis(string content)
        {
            if (content.CompareTo("Hide")==0) {
                this.Hide();
            }
            else
            {
                this.loginFlagLabel.Text = content;
            }
            ClientLogs.log(content);
        }

        public void warnMsg(string content)
        {
            throw new NotImplementedException();
        }

        private void LoginFrame_Load(object sender, EventArgs e)
        {

        }
    }
}
