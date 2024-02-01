using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace EchoLang
{
    public class Auth:Form
    {
        Label signUpLabel = theme.GenerateLabel("Sign up", 150, 15);
        Label loginLabel = theme.GenerateLabel("Log in", 300, 15);

        Panel signUpPanel = new Panel();
        Panel loginPanel = new Panel();

        //signup components
        Label firstLabel = theme.GenerateLabel("First name: ", 90, 35);
        Guna2TextBox firstBox = theme.GenerateTextBox("first name", 180, 20);
        Label lastLabel = theme.GenerateLabel("Last name: ", 90, 95);
        Guna2TextBox lastBox = theme.GenerateTextBox("last name", 180, 80);
        Label userLabel = theme.GenerateLabel("Username: ", 90, 155);
        Guna2TextBox userBox = theme.GenerateTextBox("username", 180, 140);
        Label emailLabel = theme.GenerateLabel("Email: ", 90, 215);
        Guna2TextBox emailBox = theme.GenerateTextBox("email", 180, 200);
        Label dobLabel = theme.GenerateLabel("Date of birth", 90, 275);
        Guna2DateTimePicker dobBox = new Guna2DateTimePicker();
        Label passLabel = theme.GenerateLabel("Password: ", 90, 335);
        Guna2TextBox passBox = theme.GenerateTextBox("password", 180, 320);
        Label confirmPassLabel = theme.GenerateLabel("Confirm pass", 90, 395);
        Guna2TextBox confirmPassBox = theme.GenerateTextBox("confirm password", 180, 380);
        Guna2Button signupButton= theme.GenerateButton("sign up",180,440);

        //login components
        Label loginUserLabel = theme.GenerateLabel("username",90, 140);
        Guna2TextBox loginUserBox = theme.GenerateTextBox("username", 180, 125);
        Label loginPassLabel = theme.GenerateLabel("Password", 90, 200);
        Guna2TextBox loginPassBox = theme.GenerateTextBox("password", 180, 185);
        Guna2Button loginButton = theme.GenerateButton("login", 180, 245);

        Guna2ToggleSwitch ts = new Guna2ToggleSwitch();
        public Auth()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
          
        }

        private void ClearInputFields()
        {
 
        }
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            this.Text = "Sign Up Form"; // Title of the form
            this.Size = new Size(500, 600); // Width and height of the form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(255,255,255,255);

            ts.Size= new Size(68, 25);
            ts.Location = new Point(220, 10);
            ts.CheckedState.FillColor = theme.BUTTONBACKCOLOR;
            ts.CheckedChanged += (o, e) => { togelPanels(); };

            signUpPanel.Size = new Size(500, 500);
            signUpPanel.Location = new Point(0, 50);
            loginPanel.Size = new Size(500, 500);
            loginPanel.Location = new Point(0, 50);
            //signUpPanel.BackColor = Color.White;
            signUpPanel.Controls.Add(firstLabel);
            signUpPanel.Controls.Add(firstBox);
            signUpPanel.Controls.Add(lastLabel);
            signUpPanel.Controls.Add(lastBox);
            signUpPanel.Controls.Add(userLabel);
            signUpPanel.Controls.Add(userBox);
            signUpPanel.Controls.Add(emailLabel);
            signUpPanel.Controls.Add(emailBox);
            signUpPanel.Controls.Add(dobLabel);
            signUpPanel.Controls.Add(dobBox);
            dobBox.Location = new Point(180, 260);
            signUpPanel.Controls.Add(passLabel);
            signUpPanel.Controls.Add(passBox);
            signUpPanel.Controls.Add(confirmPassLabel);
            signUpPanel.Controls.Add(confirmPassBox);
            signUpPanel.Controls.Add(signupButton);
            signupButton.Click += (o, e) => handleSignup();
            //login panel adds
            loginPanel.Visible = false;
            loginPanel.Controls.Add(loginUserLabel);
            loginPanel.Controls.Add(loginUserBox);
            loginPanel.Controls.Add(loginPassLabel);
            loginPanel.Controls.Add(loginPassBox);
            loginPanel.Controls.Add(loginButton);
            loginButton.Click += (o, e) => handleLogin();

            passBox.PasswordChar = '*';
            confirmPassBox.PasswordChar = '*';
            loginPassBox.PasswordChar = '*';    




            Controls.Add(ts);
            Controls.Add(signUpLabel);
            Controls.Add(loginLabel);
            Controls.Add(signUpPanel);
            Controls.Add(loginPanel);
        }
        private void togelPanels()
        {
            if (!ts.Checked)
            {
                signUpPanel.Visible = true;
                loginPanel.Visible = false;
            }
            else
            {
                signUpPanel.Visible = false;
                loginPanel.Visible = true;
            }
        }
        private void handleSignup()
        {
    
            if(firstBox.Text.Length == 0) {
                firstBox.FillColor = Color.Red;
                confirmPassBox.FillColor = Color.White;
                passBox.FillColor = Color.White;
                emailBox.FillColor = Color.White;
                userBox.FillColor = Color.White;
                lastBox.FillColor = Color.White;
            }
            else if(lastBox.Text.Length ==0)
            {
                confirmPassBox.FillColor = Color.White;
                passBox.FillColor = Color.White;
                emailBox.FillColor = Color.White;
                userBox.FillColor = Color.White;
                firstBox.FillColor = Color.White;
                lastBox.FillColor = Color.Red;
            }
            else if(userBox.Text.Length==0 || !database.validateUsername(userBox.Text))
            {
                confirmPassBox.FillColor = Color.White;
                passBox.FillColor = Color.White;
                emailBox.FillColor = Color.White;
                lastBox.FillColor = Color.White;
                firstBox.FillColor = Color.White;
                userBox.FillColor = Color.Red;
            }
            else if(!database.validateEmail(emailBox.Text))
            {
                confirmPassBox.FillColor = Color.White;
                passBox.FillColor = Color.White;
                userBox.FillColor = Color.White;
                lastBox.FillColor = Color.White;
                firstBox.FillColor = Color.White;
                emailBox.FillColor = Color.Red;
            }else if(passBox.Text.Length<8)
            {
                confirmPassBox.FillColor = Color.White;
                emailBox.FillColor = Color.White;
                userBox.FillColor = Color.White;
                lastBox.FillColor = Color.White;
                firstBox.FillColor = Color.White;
                passBox.FillColor = Color.Red;
            }else if (passBox.Text!=confirmPassBox.Text)
            {
                passBox.FillColor = Color.White;
                emailBox.FillColor = Color.White;
                userBox.FillColor = Color.White;
                lastBox.FillColor = Color.White;
                firstBox.FillColor = Color.White;
                confirmPassBox.FillColor = Color.Red;
            }
            else
            {
                confirmPassBox.FillColor = Color.White;
                passBox.FillColor = Color.White;
                emailBox.FillColor = Color.White;
                userBox.FillColor = Color.White;
                lastBox.FillColor = Color.White;
                firstBox.FillColor = Color.White;
                database.insertUser(userBox.Text, passBox.Text, emailBox.Text, firstBox.Text, lastBox.Text, dobBox.Text);
                Dictionary<string, string> md = database.fetchUserByUsername(userBox.Text);
                database.stateManager = int.Parse( md["userId"]);
               
                
                Form1 newform = new Form1();
                newform.Show();
                this.Hide();

            }
        }
        private void handleLogin()
        {
            Dictionary<string, string> md = database.fetchUserByUsername(loginUserBox.Text);
            
            if(md == null)
            {
                loginUserBox.FillColor = Color.Red;
                loginPassBox.FillColor = Color.White;

            }
            else if(loginPassBox.Text != md["password"])
            {
                loginUserBox.FillColor = Color.White;
                loginPassBox.FillColor = Color.Red;
            }
            else
            {
                loginUserBox.FillColor = Color.White;
                loginPassBox.FillColor = Color.White;
                
                database.stateManager = int.Parse(md["userId"]);
                this.Hide();
                Form1 newform = new Form1();
                newform.Show();


            }
        }

    }
}
