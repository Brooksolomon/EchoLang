﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoLang
{
    public class coursesPanel:Panel
    {
        List<Panel> panels = new List<Panel>();
        List<Guna2Button> buttons = new List<Guna2Button>();
        Guna2TextBox search = new Guna2TextBox();
        public coursesPanel()
        {
            this.Location = theme.MAINPANELPOINT;
            this.Size = theme.MAINPANELSIZE;
            this.BackColor = theme.MAINPANELBACKGROUND;
            
            // search bar
            search.BorderRadius = 20;
            search.Location = new Point(170, 40);
            search.Size = new Size(441, 40);
            search.AcceptsReturn = true;
            search.PlaceholderText = "Search Course";
            search.IconLeft = Image.FromFile("C:\\Users\\offic\\source\\repos\\EchoLang\\images\\search.png");
            search.Font = new Font("Arial", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            search.ForeColor = Color.FromArgb(64, 64, 64);
            Controls.Add(search);
            search.TextChanged += (e, c) => generateContent(search.Text);

            generateContent("");
        }
        public void generateContent(string texter)
        {
            for (int i = Controls.Count - 1; i > 0; i--)
            {
                Controls.RemoveAt(i);
            }

            Panel p1 = new Panel();
            p1.AutoScroll = true;
            p1.Size = new Size(800, 670);
            p1.Location = new Point(0, 140);
            p1.Visible = true;
            p1.BackgroundImage = Properties.Resources.bg;


            int starty = 20;
            List<Course> courses = database.fetchAllCourses();
            foreach (Course course in courses)
            {
                if (course.title.ToLower().Contains(texter.ToLower())) { 
                    Guna2Panel tp = theme.GenerateCourseCards(course, 110, starty);
                    tp.Click += (o, e) => { openCourse(course.id); };
                    p1.Controls.Add(tp);


                    starty += 100;
                }

            }
            panels.Add(p1);
            buttons.Add(theme.GenerateButton("skip", 0, 0));
            Controls.Add(p1);
        }
        public void openCourse(int id)
        {
            for (int i = 0; i < panels.Count; i++)
            {

                panels[i].Visible = false;
                buttons[i].ForeColor = theme.MainTextColor;
                buttons[i].FillColor = theme.MAINPANELBACKGROUND;

            }

            Panel p1 = new Panel();
            panels.Add(p1);
            buttons.Add(theme.GenerateButton("skip", 0, 0));
            p1.AutoScroll = true;
            p1.Size = new Size(800, 670);
            p1.Location = new Point(0, 140);

            List<Question> list = database.fetchQuestionByCourse(id);
            int starty = 20;
            int index = 1;
            int score = 0;
            int answered = 0;
            Guna2Button finButton = theme.GenerateButton("Finish", 600, starty);
            finButton.Enabled = false;
            foreach (Question question in list)
            {
                Guna2Panel panel = new Guna2Panel();
                panel.Size = new Size(600, 180);
                panel.Location = new Point(50, starty);
                panel.BorderColor = theme.BUTTONBACKCOLOR;
                panel.BorderThickness = 3;


                Label label = new Label();
                // TextComp text = new TextComp();
                label.Text = index.ToString() + "," + question.quest;
                label.Size = new Size(600, 60);
                label.Location = new Point(20, 20);
                label.ForeColor = theme.MainTextColor;
                label.Font = new Font("Arial", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

                Guna2Button button = theme.GenerateButton("Check", 400, 120);

                Random random = new Random();
                int questionType = random.Next(1, 3);
                if (questionType == 1)
                {
                    Label label1 = new Label();
                    label1.Text = question.answer;
                    label1.Size = new Size(150, 50);
                    label1.Location = new Point(220, 90);
                    label1.ForeColor = theme.MainTextColor;
                    label1.Font = new Font("Arial", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    label1.Visible = false;


                    Guna2TextBox textBox = theme.GenerateTextBox("answer", 20, 80);

                    button.Click += (o, e) =>
                    {
                        answered += 1;
                        if (question.answer.ToLower() == textBox.Text.ToLower().Trim())
                        {
                            panel.BackColor = Color.GreenYellow;
                            score += 1;
                        }
                        else
                        {
                            panel.BackColor = Color.Red;
                            label1.Visible = true;
                        }
                        button.Enabled = false;
                        if (answered == 10)
                        {
                            finButton.Enabled = true;
                        }
                    };

                    panel.Controls.Add(label1);
                    panel.Controls.Add(textBox);






                }
                else if (questionType == 2)
                {
                    string[] mixedWords = {
                    "Elephant", "Elefante", "Beach", "Playa", "City", "Ciudad", "Star", "Estrella", "Shoe", "Zapato",
                    "Ship", "Barco", "Hat", "Sombrero", "Forest", "Bosque", "Guitar", "Guitarra", "Movie", "Película",
                    "Ice Cream", "Helado", "Rainbow", "Arcoiris", "Chair", "Silla", "Train", "Tren", "Diamond", "Diamante",
                    "Island", "Isla", "Map", "Mapa", "Garden", "Jardín", "Robot", "Robot", "Pizza", "Pizza",
                    "Elephant", "Elefante", "Ocean", "Océano", "Sand", "Arena", "Balloon", "Globo", "Sunglasses", "Gafas de sol",
                    "Dolphin", "Delfín", "Space", "Espacio", "Feather", "Pluma", "Chocolate", "Chocolate", "Dragon", "Dragón",
                    "Adventure", "Aventura", "Soccer", "Fútbol", "Puzzle", "Rompecabezas", "Tiger", "Tigre", "Journey", "Viaje",
                    "Eagle", "Águila", "Flower", "Flor", "Dragonfly", "Libélula", "Elephant", "Elefante", "Camera", "Cámara"
                };

                    Guna2GroupBox g1 = new Guna2GroupBox();
                    g1.FillColor = theme.MAINPANELBACKGROUND;
                    g1.Size = new Size(350, 100);
                    g1.Location = new Point(50, 45);
                    g1.BorderThickness = 0;
                    g1.CustomBorderThickness = new Padding(0, 0, 0, 0);

                    //g1.ForeColor = theme.MAINPANELBACKGROUND;
                    //g1.BorderColor = theme.MAINPANELBACKGROUND;
                    //g1.CustomBorderColor = theme.MAINPANELBACKGROUND;
                    panel.Controls.Add(g1);

                    Random r = new Random();
                    int ap = random.Next(1, 5);
                    List<Guna2RadioButton> choices = new List<Guna2RadioButton>();

                    for (int i = 1; i <= 4; i++)
                    {
                        Guna2RadioButton radio = new Guna2RadioButton();
                        radio.ForeColor = theme.MainTextColor;
                        radio.Size = new Size(100, 40);
                        radio.CheckedState.InnerColor = Color.Yellow;

                        if (i > 2)
                        {
                            radio.Location = new Point(180, 20 + (i - 3) * 40);

                        }
                        else
                        {
                            radio.Location = new Point(0, 20 + (i - 1) * 40);
                        }

                        if (i != ap)
                        {
                            radio.Text = mixedWords[new Random().Next(0, mixedWords.Length)];
                        }
                        else
                        {
                            radio.Text = question.answer;
                        }
                        choices.Add(radio);
                        g1.Controls.Add(radio);



                    }
                    button.Click += (o, e) =>
                    {
                        foreach (Guna2RadioButton d in choices)
                        {

                            if (d.Checked == true)
                            {
                                button.Enabled = false;
                                answered += 1;
                                if (d.Text == question.answer)
                                {
                                    panel.BackColor = Color.GreenYellow;
                                    g1.FillColor = Color.GreenYellow;
                                    score += 1;

                                }
                                else
                                {
                                    panel.BackColor = Color.Red;
                                    g1.FillColor = Color.Red;
                                    choices[ap - 1].BackColor = Color.GreenYellow;
                                    choices[ap - 1].ForeColor = Color.Black;

                                }

                                if (answered == 10)
                                {
                                    finButton.Enabled = true;
                                }

                            }
                        }

                    };



                }
                panel.Controls.Add(label);
                panel.Controls.Add(button);
                p1.Controls.Add(panel);

                starty += 200;
                index++;
            }
            finButton.Location = new Point(600, starty);
            finButton.Click += (o, e) => scorePage(score);

            p1.Controls.Add(finButton);

            Controls.Add(p1);


        }
        public void scorePage(int score)
        {
            for (int i = 0; i < panels.Count; i++)
            {

                panels[i].Visible = false;
                buttons[i].ForeColor = theme.MainTextColor;
                buttons[i].FillColor = theme.MAINPANELBACKGROUND;

            }

            Panel p1 = new Panel();
            panels.Add(p1);
            buttons.Add(theme.GenerateButton("skip", 0, 0));
            p1.AutoScroll = true;
            p1.Size = new Size(800, 670);
            p1.Location = new Point(0, 140);
            Label scoreLabel = new Label();
            scoreLabel.ForeColor = theme.BUTTONBACKCOLOR;
            scoreLabel.Text = "You scored " + score.ToString() + "/ 10";
            scoreLabel.Location = new Point(250, 150);
            scoreLabel.Size = new Size(300, 50);
            scoreLabel.Font = new Font("Arial", 26, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            UserStats userstats = database.fetchUserStats();
            int totalScore = userstats.totalPoints;

            Label totalPointLabel = new Label();
            totalPointLabel.ForeColor = theme.BUTTONBACKCOLOR;
            totalPointLabel.Text = "new total: " + totalScore.ToString() + " + " + calulatePoints(score).ToString();
            totalPointLabel.Location = new Point(250, 250);
            totalPointLabel.Size = new Size(250, 50);
            totalPointLabel.Font = new Font("Arial", 22, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            totalScore += calulatePoints(score) + 20;



            Guna2CircleProgressBar progress = new Guna2CircleProgressBar();
            progress.ProgressColor2 = theme.BUTTONBACKCOLOR;
            progress.ProgressColor = Color.Yellow;
            progress.Value = (int)(totalScore / (Math.Ceiling((double)totalScore / 30) * 30) * 100);
            progress.Size = new Size(122, 122);
            progress.Location = new Point(100, 0);
            progress.ShowText = true;

            Label levelLabel = new Label();
            levelLabel.ForeColor = theme.BUTTONBACKCOLOR;
            levelLabel.Text = "lvl " + ((int)Math.Floor((double)totalScore / 30) + 1);
            levelLabel.Size = new Size(250, 50);
            levelLabel.Font = new Font("Arial", 22, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            levelLabel.Location = new Point(250, 50);


            p1.Controls.Add(scoreLabel);
            p1.Controls.Add(totalPointLabel);
            p1.Controls.Add(progress);
            p1.Controls.Add(levelLabel);

            database.updateUserStats(database.stateManager, totalScore);
            Controls.Add(p1);
        }
        public static int calulatePoints(int score)
        {
            int ans = 0;
            ans = (int)(score * 2.5);



            return ans;
        }


    }
}   


