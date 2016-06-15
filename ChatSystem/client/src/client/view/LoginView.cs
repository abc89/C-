using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.main;
using jiami;
using client.transport;
using client.operate;
using client.data;
using System.Windows.Forms;
/// <summary>
/// Frame 与 处理之间的映射 View
/// </summary>
namespace client.view
{
    class LoginView : Recive
    {
        private Frame loginFrame;
       private LoginOperate loginOperate;
        public LoginView(Frame loginFrame1)
        {
            this.loginFrame = loginFrame1;
        }

      


        public void update()
        {
            String state = loginOperate.getDataState();
            loginFrame.changeDis(state);
        }

        internal bool login(string userName, string password)
        {
            
            String md5Pswd = JiaMi.MD5JiaMi(password);
            loginOperate = LoginOperate.getInstance();
            loginOperate.setView(this);
            bool ok = loginOperate.startLink(userName, md5Pswd);
            if (ok)
            {
                new SelfMainFrame().Show();
                loginFrame.changeDis("Hide");
            }
            return false;
        }
    }
}
