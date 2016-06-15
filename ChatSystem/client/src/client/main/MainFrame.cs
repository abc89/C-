using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.view
{
    public partial class MainFrame : Form
    {
        //逻辑界面类
        private View view;
        public MainFrame()
        {
            InitializeComponent();
         /*   if(view==null){
                this.view = new View(this);
    
            }*/
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          /*  if (this.button1.Text.CompareTo("开始链接") == 0)
            {
                Boolean ok = this.view.checkLinkContent(this.textBox1.Text, this.textBox2.Text);
                if (!ok)
                {
                    MessageBox.Show("ip或端口号错误", "Button1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.view.startLink();
                    this.button1.Text = "断开链接";
                }
            }
            else {
                view.close();
                this.button1.Text = "开始链接";
            }*/
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* this.textBox3.AppendText("\r\n" + "发送信息：" + this.textBox4.Text);
            if (view.isOpenLink())
            {
                if (textBox5.Text.CompareTo("NO") != 0)
                {
                    this.textBox3.AppendText("进入已连接单次");
                    view.sendMsg(this.textBox4.Text);
                    view.sendMsg(textBox5.Text);
                    view.close();
                }
                else {
                    Boolean ok = this.view.sendMsg(this.textBox4.Text);
                    if (!ok)
                    {
                        this.textBox3.AppendText(" 发送失败");
                        return;
                    }
                }
            } else if (!view.isOpenLink()&& textBox5.Text.CompareTo("NO") != 0) {
                this.textBox3.AppendText("进入未连接单次");
                Boolean oks = this.view.checkLinkContent(this.textBox1.Text, this.textBox2.Text);
                if (!oks)
                {
                    MessageBox.Show("ip或端口号错误", "Button1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.view.startLink();
                    view.sendMsg(this.textBox4.Text);
                    view.sendMsg(textBox5.Text);
                    view.close();
                    this.button1.Text = "断开链接";
                }

            }
          */
          
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.textBox1.Text = this.buttonChange.Name;
        
        }
    }
}
