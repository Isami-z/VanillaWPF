using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VanillaWPF
{
    public class GuideVo
    {
        private FrameworkElement uc;
        private string content;

        public FrameworkElement Uc
        {
            get { return uc; }
            set { uc = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }

}
