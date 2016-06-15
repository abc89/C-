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
    public partial class LogFrame : Form
    {
        private LogView view;
        //自定义委托类型，委托签名（解释见PPT）与该委托将要绑定的方法签名应保持一致（本例为不带参数的方法）
        //委托类型应在本处而不能在方法里面定义
        public delegate void ReadSptEventHandler();
        private String updateContent;
        public LogFrame()
        {
            InitializeComponent();
            view = LogView.getInstance();
            view.setFrame(this);
           
        }
        internal void display(String vs)
        {
            ReadSptEventHandler rse = new ReadSptEventHandler(show);
            this.updateContent = vs;
            textBox1.Invoke(rse);
        }
        public void show()
        {
            textBox1.AppendText("\r\n" + updateContent);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
