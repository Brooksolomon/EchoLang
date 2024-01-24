using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoLang
{
    public class coursesPanel:Panel
    {
        public coursesPanel()
        {
            this.Location = theme.MAINPANELPOINT;
            this.Size = theme.MAINPANELSIZE;
            this.BackColor = theme.MAINPANELBACKGROUND;
        }
    }
}
