using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace EchoLang
{
    public class profilePanel:Panel
    {
        Label firstLabel = theme.GenerateLabel("First name: ",50,110);
        Guna2TextBox firstBox = theme.GenerateTextBox("first name", 140, 100);
        Label userLabel = theme.GenerateLabel("Username: ", 330, 110);
        Guna2TextBox userBox = theme.GenerateTextBox("username", 420, 100);
        Label lastLabel = theme.GenerateLabel("Last name: ", 50, 170);
        Guna2TextBox lastBox = theme.GenerateTextBox("last name", 140, 160);
        Label emailLabel = theme.GenerateLabel("Email: ", 330, 170);
        Guna2TextBox emailBox = theme.GenerateTextBox("email", 420, 160);
        Label dobLabel = theme.GenerateLabel("Date of birth", 50, 230);
        Guna2TextBox dobBox = theme.GenerateTextBox("date of birth: ", 140, 220);
        Label passLabel = theme.GenerateLabel("Password: ", 330, 230);
        Guna2TextBox passBox = theme.GenerateTextBox("password", 420, 220);
        

        Guna2Button editButton = theme.GenerateButton("Edit profile", 440, 300);
        Guna2Button saveButton = theme.GenerateButton("Save Changes", 580, 300);
        public profilePanel() {
            this.Location = theme.MAINPANELPOINT;
            this.Size = theme.MAINPANELSIZE;
            this.BackColor = theme.MAINPANELBACKGROUND;



            firstBox.Enabled = false;
            userBox.Enabled = false;
            lastBox.Enabled = false;
            emailBox.Enabled = false;
            dobBox.Enabled = false;
            passBox.Enabled = false;
            Dictionary<string, string> myDictionary = database.fetchSpecificUser(database.stateManager);
            firstBox.Text = myDictionary["firstName"];
            userBox.Text = myDictionary["username"];
            lastBox.Text = myDictionary["lastName"];
            emailBox.Text = myDictionary["email"];
            dobBox.Text = myDictionary["dob"];
            passBox.Text = myDictionary["password"];
            passBox.PasswordChar = '*';
            



            saveButton.Enabled = false;
            editButton.Click += (s, e) => { toggleFeilds();  };
            saveButton.Click += (s, e) => { updateUserData(); };

            Label secondHeader = theme.GenerateLabel("user stats", 50, 360);
            secondHeader.Size = new Size(120, 30);
            secondHeader.Font = new Font("Arial", 18, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            UserStats userstats = database.fetchUserStats();
            int totalScore = userstats.totalPoints;

            Guna2CircleProgressBar progress = new Guna2CircleProgressBar();
            progress.ProgressColor2 = theme.BUTTONBACKCOLOR;
            progress.ProgressColor = Color.Yellow;
            progress.Value = (int)(totalScore / (Math.Ceiling((double)totalScore / 30) * 30) * 100);
            progress.Size = new Size(200, 200);
            progress.Location = new Point(100, 400);
            progress.ShowText = true;

            Label levelLabel = new Label();
            levelLabel.ForeColor = theme.BUTTONBACKCOLOR;
            levelLabel.Text = "lvl " + ((int)Math.Floor((double)totalScore / 30) + 1);
            levelLabel.Size = new Size(250, 50);
            levelLabel.Font = new Font("Arial", 22, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            levelLabel.Location = new Point(330, 450);

            Controls.Add(firstLabel);
            Controls.Add(userBox);
            Controls.Add(userLabel);
            Controls.Add(firstBox);
            Controls.Add(lastLabel);
            Controls.Add(lastBox);
            Controls.Add(emailLabel);
            Controls.Add(emailBox);
            Controls.Add(dobLabel);
            Controls.Add(dobBox);
            Controls.Add(passLabel);
            Controls.Add(passBox);
            Controls.Add(editButton);
            Controls.Add(saveButton);
            Controls.Add(secondHeader);
            Controls.Add(progress);
            Controls.Add(levelLabel);


        }
        public void toggleFeilds()
        {
            firstBox.Enabled = !firstBox.Enabled;
            userBox.Enabled = !userBox.Enabled;
            lastBox.Enabled = !lastBox.Enabled;
            emailBox.Enabled = !emailBox.Enabled;
            dobBox.Enabled = !dobBox.Enabled;
            passBox.Enabled = !passBox.Enabled;
            saveButton.Enabled = !saveButton.Enabled;
            if(editButton.Text == "Edit profile")
            {
                editButton.Text = "Cancel";
            }
            else
            {
                editButton.Text = "Edit profile";
            }

        }

        public void updateUserData()
        {
            if(!database.validateEmail(emailBox.Text))
            {
                emailBox.FillColor= Color.Red;  
                emailBox.ForeColor= Color.White;
            }
            else
            {
                emailBox.FillColor= Color.White;
                emailBox.ForeColor= Color.Black;
                toggleFeilds();
                database.updateUser(database.stateManager,userBox.Text,passBox.Text,emailBox.Text,firstBox.Text,lastBox.Text,dobBox.Text);
                MessageBox.Show("Changes set");

            }
        }

    }
}
