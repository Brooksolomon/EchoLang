using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;

namespace EchoLang
{
    public class dictpanel:Panel
    {
        public Label pageHeader;
        public dictpanel()
        {
            this.Location = theme.MAINPANELPOINT;
            this.Size = theme.MAINPANELSIZE;
            this.BackColor = theme.MAINPANELBACKGROUND;
            generateContent();

           

        }
        public void generateContent()
        {
            Controls.Clear();
            pageHeader = new Label();
            pageHeader.Text = "Select language";
            pageHeader.Font = new Font("Arial", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pageHeader.Location = new Point(30, 30);
            pageHeader.Size = new Size(200, 40);
            pageHeader.ForeColor = theme.MainTextColor;

            List<Language> languages = database.fetchLeanringLanguages();
            int starty = 0;
            int count = 1;
            Panel p1 = new Panel();
            p1.AutoScroll = true;
            p1.Size = new Size(800, 670);
            p1.Location = new Point(0, 140);
            p1.BackgroundImage = Properties.Resources.bg;

            foreach (Language language in languages)
            {
                Guna2Button button = new Guna2Button();
                if (count % 3 == 1)
                {
                    button = theme.GenerateButton(language.name, 160, starty);

                }
                else if (count % 3 == 2)
                {
                    button = theme.GenerateButton(language.name, 300, starty);


                }
                else
                {
                    button = theme.GenerateButton(language.name, 440, starty);
                    starty += 100;
                }
                count += 1;
                button.Size = new Size(100, 45);
                button.Click += (o, e) => selectHandler(language.id);
                p1.Controls.Add(button);
            }




            Controls.Add(pageHeader);
            Controls.Add(p1);

        }
        public void selectHandler(int langid)
        {

            pageHeader.Text = "Common Phrases";
            for (int i = Controls.Count - 1; i > 0; i--)
            {
                Controls.RemoveAt(i);
            }

            Panel p1 = new Panel();
            p1.AutoScroll = true;
            p1.Size = new Size(800, 710);
            p1.Location = new Point(0, 100);
            

            List<Phrase> phrases = database.fetchPhrasesByLanguage(langid);

            int starty = 20;
            int index = 1;
            Guna2Button finButton = theme.GenerateButton("Back", 600, starty);

            foreach (Phrase phrase in phrases)
            {
                Guna2Panel panel = new Guna2Panel();
                panel.Size = new Size(600, 100);
                panel.Location = new Point(50, starty);
                panel.BorderColor = Color.Orange;
                panel.BorderThickness = 3;
                panel.BackColor = theme.BUTTONBACKCOLOR;



                Label label = new Label();
                label.Text = index.ToString() + "," + phrase.phrase;
                label.Size = new Size(500, 30);
                label.Location = new Point(20, 20);
                label.ForeColor = theme.MainTextColor;
                label.Font = new Font("Arial", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                panel.Controls.Add(label);

                Label meaning  = new Label();
                meaning.Text = "Meaning: " + phrase.meaning;
                meaning.Size = new Size(500, 30);
                meaning.Location = new Point(40, 60);
                meaning.ForeColor = theme.MainTextColor;
                meaning.Font = new Font("Arial", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                panel.Controls.Add(meaning);

                p1.Controls.Add(panel);

                starty += 120;
                index++;
            }
            finButton.Location = new Point(600, starty);
            finButton.Click += (o, e) => { generateContent(); };

            p1.Controls.Add(finButton);
            Controls.Add(p1);
            

            


        }

    }
}
