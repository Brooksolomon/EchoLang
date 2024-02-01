using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;

namespace EchoLang
{

    public class theme
    {
        public static Color MAINPANELBACKGROUND = Color.FromArgb(255,255,255,255);
        public static Color MainTextColor = Color.Black;
        public static Point MAINPANELPOINT = new Point(242, 0);
        public static Size MAINPANELSIZE = new Size(800, 2000);
        public static Color BUTTONBACKCOLOR = Color.Orange;
        public static Guna2Button GenerateButton(string text, int x, int y)
        {
            Guna2Button button = new Guna2Button();
            button.Text = text;
            
            button.Location = new Point(x, y);
            button.Size = new Size(120, 50);
            button.Font = new Font("Arial", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button.BorderColor = theme.BUTTONBACKCOLOR;
            button.BorderThickness = 3;
            button.FillColor = theme.MAINPANELBACKGROUND;
            button.ForeColor = theme.MainTextColor;
            button.HoverState.FillColor = theme.BUTTONBACKCOLOR;
            button.HoverState.ForeColor = Color.White;
            button.BorderRadius = 20;

            return button;

        }
        public static Panel GenerateUserCard(string name, string username, int level,int x, int y)
        {

            Guna2Panel panel = new Guna2Panel();
            panel.FillColor = Color.Orange;
            panel.BorderRadius = 30;
            panel.Size = new Size(250, 80);
            panel.Location = new Point(x, y);
            Label levelLabel = new Label();
            string lvl = "lvl " + level.ToString();
            levelLabel.Text =lvl;
            levelLabel.BackColor = BUTTONBACKCOLOR;
            levelLabel.ForeColor = Color.White;
            levelLabel.Location = new Point(10, 26);
            levelLabel.Size = new Size(40, 30);
            levelLabel.Font = new Font("Arial", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Label nameLabel = new Label();
            nameLabel.Text = name;
            nameLabel.BackColor = BUTTONBACKCOLOR;
            nameLabel.ForeColor = Color.White;
            nameLabel.Location = new Point(40, 10);
            nameLabel.Size = new Size(200, 22);
            nameLabel.Font = new Font("Arial", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Label userlabel = new Label();
            userlabel.Text = username;
            userlabel.BackColor = BUTTONBACKCOLOR;
            userlabel.ForeColor = Color.White;
            userlabel.Location = new Point(40, 40);
            userlabel.Font = new Font("Arial", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            panel.Controls.Add(nameLabel);
            panel.Controls.Add(userlabel);
            panel.Controls.Add(levelLabel);


            return panel;
        }
        public static Guna2TextBox GenerateTextBox(string placeholder, int x, int y)
        {
            Guna2TextBox textBox = new Guna2TextBox();
            textBox.Location = new Point(x, y);
            textBox.BorderRadius = 20;
            textBox.PlaceholderText = placeholder;
            textBox.PlaceholderForeColor = Color.Gray;
            textBox.BorderColor = BUTTONBACKCOLOR;
            textBox.BorderThickness = 1;
            textBox.ForeColor = Color.Black;
            textBox.Size = new Size(180, 40);
            textBox.Font = new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            textBox.DisabledState.BorderColor = BUTTONBACKCOLOR;

            return textBox;
        }
        public static Label GenerateLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.Size = new Size(90, 30);
            label.ForeColor = MainTextColor;
            label.Font = new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            return label;
        }
        public static Guna2Panel GenerateCourseCards(Course c,int x, int y)
        {
            Guna2Panel panel = new Guna2Panel();
            panel.FillColor = BUTTONBACKCOLOR;
            panel.Size = new Size(550, 90);
            panel.ForeColor = Color.Black;
            panel.BorderRadius = 10;
            panel.Location = new Point(x, y);

            Label title = new Label();
            title.Text = c.title;
            title.Location = new Point(27,10);
            title.Size = new Size(400, 25);
            title.ForeColor = Color.Black;
            title.Font = new Font("Arial", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            title.BackColor = BUTTONBACKCOLOR;

            Guna2TextBox textBox = new Guna2TextBox();
            textBox.Multiline = true;
            textBox.Text = c.description;
            textBox.Enabled = false;
            textBox.Location = new Point(25, 35);
            textBox.Size = new Size(400, 50);
            textBox.DisabledState.ForeColor = Color.Black;
            textBox.DisabledState.FillColor = BUTTONBACKCOLOR;
            textBox.Font = new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox.BorderThickness = 0;

            Guna2TextBox level = new Guna2TextBox();
            level.Size = new Size(60,  20);
            level.Location = new Point(480, 0);
            level.BorderThickness = 5;
            //level.BorderRadius = 10;
            //level.DisabledState.FillColor = BUTTONBACKCOLOR;
            level.BackColor = BUTTONBACKCOLOR;
            level.TextAlign = HorizontalAlignment.Center;
            level.Enabled = false;
            level.DisabledState.ForeColor = Color.Black;
            
           
            
            if(c.level ==1)
            {
                level.DisabledState.BorderColor = Color.Green;
                level.DisabledState.FillColor = Color.Green;
                level.Text = "EASY";
            }
            else if (c.level ==2){
                level.DisabledState.BorderColor = Color.Yellow;
                level.DisabledState.FillColor = Color.Yellow;
                level.Text = "MEDIUM";
            }
            else if (c.level == 3)
            {
                level.DisabledState.BorderColor = Color.Red;
                level.DisabledState.FillColor = Color.Red;
                level.Text = "HARD";
            }
            else if(c.level == 4)
            {
                level.DisabledState.BorderColor= Color.RebeccaPurple;
                level.DisabledState.FillColor = Color.RebeccaPurple;
                level.Text = "EXPERT";
            }

            panel.Controls.Add(title);
            panel.Controls.Add(textBox);
            panel.Controls.Add(level);
            
            



            return panel;
        }

        public class deleteModal :Form
            {
                public deleteModal(int id) {

                this.Text = "Delete modal"; // Title of the form
                this.Size = new Size(500, 300); // Width and height of the form
                this.StartPosition = FormStartPosition.CenterScreen;
               this.BackColor = Color.White;

                Label label = new Label();
                label.Text = "Delete Langauge";
                label.Location = new Point(150, 80);
                label.Size = new Size(300, 40);
                label.ForeColor = MainTextColor;
                label.Font = new Font("Arial", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

                Guna2Button cancelButton = GenerateButton("Cancel", 120, 120);
                Guna2Button deleteButton = GenerateButton("Delete", 260, 120);
                deleteButton.BorderColor = Color.IndianRed;
                deleteButton.FillColor = Color.IndianRed;
                deleteButton.HoverState.FillColor = Color.IndianRed;

                cancelButton.Click += (o, e) => this.Close();
                deleteButton.Click += (o, e) => { database.DeleteuserLearning(id); this.Close();};

                Controls.Add(label);
                Controls.Add(cancelButton);
                Controls.Add(deleteButton);

            }

            private void DeleteButton_Click(object? sender, EventArgs e)
            {
                throw new NotImplementedException();
            }
        }
    public class addModal:Form
        {
            public addModal() {
                this.Text = "add modal"; // Title of the form
                this.Size = new Size(500, 300); // Width and height of the form
                this.StartPosition = FormStartPosition.CenterScreen;
                this.BackColor = Color.White;

                Label label = new Label();
                label.Text = "Select a  Langauge";
                label.Location = new Point(150, 80);
                label.Size = new Size(300, 40);
                label.ForeColor = MainTextColor;
                label.Font = new Font("Arial", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

                Guna2ComboBox comboBox = new Guna2ComboBox();
                comboBox.Location= new Point(180, 120);
                comboBox.Size = new Size(120, 100);
                List<Language> languages = database.fetchAllLanguagesThatIDontLearn(database.stateManager);
                Dictionary<string, int> myReference= new Dictionary<string, int>();
                foreach (Language language in languages)
                {
                    myReference[language.name] = language.id;
                    comboBox.Items.Add(language.name);
                }
                if (comboBox.Items.Count == 0)
                {
                    
                }

                Guna2Button cancelButton = GenerateButton("Cancel", 120, 160);
                Guna2Button addButton = GenerateButton("Add", 260, 160);
                addButton.FillColor = BUTTONBACKCOLOR;

                addButton.Enabled=false;
                comboBox.SelectedIndexChanged += (o, e) => { addButton.Enabled = true; };
                cancelButton.Click += (o, e) => this.Close();
                addButton.Click += (o, e) => { database.insertuserLearning(myReference[comboBox.SelectedItem.ToString()]);this.Close(); };
               
                Controls.Add(cancelButton);
                Controls.Add(addButton);
                Controls.Add(label);
                Controls.Add(comboBox);
                

            }
            
        }

    }
    
}
