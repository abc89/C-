using client.main;
using client.operate;
using client.transport;
using jiami;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.view 
{
    class RegistView : Recive
{
        private Frame registFrame;
        private RegistOperate registOperate;
        public RegistView(Frame frame)
        {
            this.registFrame = frame;
        }

        internal bool regist(string userName, string password)
        {
            String md5Pswd = JiaMi.MD5JiaMi(password);
            registOperate = RegistOperate.getInstance();
            registOperate.setView(this);
            registOperate.startRegist(userName, md5Pswd);

            return false;
        }



        public void update()
        {
            String state = registOperate.getDataState();
            registFrame.changeDis(state);
        }

    }
    }
