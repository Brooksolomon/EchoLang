using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoLang
{
    public class Language
    {
        public int id;
        public string name;
        public string code;
        public Language(int id,string name , string code) {
            this.id = id;   
            this.name = name;
            this.code = code;
        }
    }
    public class Course
    {
        public int id;
        public string title;
        public string description;
        public int languageID;
        public int level;
        public float price;
        public Course(int id, string title, string description, int languageID, int level, float price)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.languageID = languageID;
            this.level = level;
            this.price = price;
        }
    }
    public class Question 
    {
        public int id;
        public string quest;
        public string answer;
        public int courseID;
        public Question(int id, string quest, string answer, int courseID)
        {
            this.id = id;
            this.quest = quest;
            this.answer = answer;
            this.courseID = courseID;
        }
    }
    public class UserStats
    {
        public int id;
        public int userID;
        public int level;
        public int totalPoints;
        public UserStats(int id, int userID, int level, int totalPoints)
        {
            this.id = id;
            this.userID = userID;
            this.level = level;
            this.totalPoints = totalPoints;
        }
    }


}
