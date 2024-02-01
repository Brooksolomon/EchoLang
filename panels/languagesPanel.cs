using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace EchoLang
{
    public class languagesPanel : Panel
    {
        public languagesPanel()
        {
            this.Location = theme.MAINPANELPOINT;
            this.Size = theme.MAINPANELSIZE;
            this.BackColor = theme.MAINPANELBACKGROUND;
            this.BackgroundImage = Properties.Resources.bg;

            generateLangs();      

        }
        public  void generateLangs()
        {
            Controls.Clear();
            Label header = new Label();
            header.Text = "Languages you are currently learning";
            header.ForeColor = theme.MainTextColor;
            header.Font = new Font("Arial", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            header.Location = new Point(30, 30);
            header.Size = new Size(400, 40);
            Controls.Add(header);
            int start = 200;
            bool second = false;
            List<Language> listOfLanguages = database.fetchLeanringLanguages();
            foreach (Language language in listOfLanguages)
            {
                if (!second)
                {
                    Guna2Button temp1 = theme.GenerateButton(language.name, 220, start);
                    temp1.FillColor = theme.BUTTONBACKCOLOR;
                    temp1.ForeColor = Color.Black;
                    temp1.Click += (o, e) => { new theme.deleteModal( language.id).ShowDialog(); generateLangs(); };
                    Controls.Add(temp1);
                }
                else
                {
                    Guna2Button temp1 = theme.GenerateButton(language.name, 420, start);
                    temp1.FillColor = theme.BUTTONBACKCOLOR;
                    temp1.ForeColor = Color.Black;
                    temp1.Click += (o, e) => { new theme.deleteModal(language.id).ShowDialog(); generateLangs(); };
                    Controls.Add(temp1);
                    start += 100;
                }
                second = !second;
            }
            Guna2Button temp2;
            if (!second) 
             temp2 = theme.GenerateButton("Add language", 330, start);
            else
                temp2 = theme.GenerateButton("Add language", 330, start+100);

            temp2.Click += (o, e) => { new theme.addModal().ShowDialog(); generateLangs(); };

            

            Controls.Add(temp2);

        }
    }
}
