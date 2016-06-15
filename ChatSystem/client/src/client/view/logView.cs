using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.main;

namespace client.view
{
    class LogView
    {
        private static LogView view = new LogView();
        private LogFrame frame;
        internal static LogView getInstance()
        {
            return view;
        }

   
        /// <summary>
        /// 设置关联界面 实例
        /// </summary>
        /// <param name="logFrame"></param>
        internal void setFrame(LogFrame logFrame)
        {
          this.frame=logFrame;
        }

        public void display(String content) {
            if (frame!=null) {
                frame.display(content);
            }
        }
    }
}
