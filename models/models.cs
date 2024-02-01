using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoLang
{
    public class User
    {
        public int id;
        public string username;
        public string password;
        public string email;
        public string firstName;
        public string lastName;
        public DateTime dob;
        public int level;

        public User(int id, string username, string password, string email, string firstName, string lastName, DateTime dob, int level)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dob = dob;
            this.level = level;
        }
    }
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
        public Course(int id, string title, string description, int languageID, int level)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.languageID = languageID;
            this.level = level;
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
    public class Phrase
    {
        public int id;
        public string phrase;
        public string meaning;
        public int languageID;
        public Phrase(int id, string phrase, string meaning, int languageID)
        {
            this.id = id;
            this.phrase = phrase;
            this.meaning = meaning;
            this.languageID = languageID;
        }
    }


}
