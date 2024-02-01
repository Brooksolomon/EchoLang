using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;

namespace EchoLang
{
    public class userspanel:Panel
    {
        Guna2TextBox search = new Guna2TextBox();
        public userspanel() {
            this.Location = theme.MAINPANELPOINT;
            this.Size = theme.MAINPANELSIZE;
            this.BackColor = theme.MAINPANELBACKGROUND;
            this.BackgroundImage = Properties.Resources.bg;

            //search Bar
            
            search.BorderRadius = 20;
            search.Location = new Point(170, 40);
            search.Size = new Size(441, 40);
            search.AcceptsReturn = true;
            search.PlaceholderText = "Search user";
            search.IconLeft = Image.FromFile("C:\\Users\\offic\\source\\repos\\EchoLang\\images\\search.png");
            search.Font = new Font("Arial", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            search.ForeColor = Color.FromArgb(64, 64, 64);
            Controls.Add(search);
            search.TextChanged += (e, c) =>  renderUsers(search.Text);

            renderUsers("");

            
            
        }
        public  void renderUsers(string text)
        {
            int start = 200;
            bool second = false;
            for (int i = Controls.Count - 1; i > 0; i--)
            {
                Controls.RemoveAt(i);
            }
            List<User> holdUsers = database.fetchAllUsers();
            foreach (var i in holdUsers)
            {
                if ((i.firstName.ToLower().Contains(text.ToLower()) || i.lastName.ToLower().Contains(text.ToLower())) && i.id != database.stateManager)
                {
                    if (!second)
                    {
                        Panel temp1 = theme.GenerateUserCard(i.firstName + ' ' + i.lastName, '@' + i.username,i.level, 80, start);
                        Controls.Add(temp1);
                    }
                    else
                    {
                        Panel temp1 = theme.GenerateUserCard(i.firstName + ' ' + i.lastName, '@' + i.username,i.level, 420, start);
                        Controls.Add(temp1);
                        start += 100;
                    }
                    second = !second;
                }

                
            }

        }
    }
}
