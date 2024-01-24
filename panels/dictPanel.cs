using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;

namespace EchoLang
{
    public class dictpanel:Panel
    {
        public Guna2Button engbButton, spButton, frButton,turButton;
        public Label pageHeader;
        public dictpanel()
        {
            this.Location = theme.MAINPANELPOINT;
            this.Size = theme.MAINPANELSIZE;
            this.BackColor = theme.MAINPANELBACKGROUND;

            pageHeader = new Label();
            pageHeader.Text = "Select language";
            pageHeader.Font = new Font("Arial", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pageHeader.Location = new Point(30, 30);
            pageHeader.Size = new Size(200,40);
            pageHeader.ForeColor = Color.White;


            engbButton = theme.GenerateButton("English",220,200);
            spButton = theme.GenerateButton("Spanish", 420, 200);
            frButton = theme.GenerateButton("French", 220, 280);
            turButton = theme.GenerateButton("Turkish", 420, 280);

            


            Controls.Add(pageHeader);
            Controls.Add(engbButton);
            Controls.Add(spButton);
            Controls.Add(frButton);
            Controls.Add(turButton);



        }
    }
}
