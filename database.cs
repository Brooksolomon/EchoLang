using Microsoft.VisualBasic.ApplicationServices;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace EchoLang
{

    public class database
    {
        public static int stateManager=9;
        public static string connectionString = "Data Source=DESKTOP-BP45MS8;Initial Catalog=EchoLang;Integrated Security=True;";
        public static List<Dictionary<string,string>> fetchAllUsers()
        {
            
            List<Dictionary<string, string>> listOfDictionaries = new List<Dictionary<string, string>>();

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("select * from users", connection))
                {
                    
                    // Execute the query and get a SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                       
                        // Check if there are rows in the result set
                        if (reader.HasRows)
                        {

                           
                            // Iterate through the rows
                            while (reader.Read())
                            {
                                Dictionary<string,string> temp = new Dictionary<string, string>();
                                // Access data using column names or indices
                                temp["userId"] = reader.GetInt32(0).ToString();
                                temp["username"] = reader.GetString(1);
                                temp["password"] = reader.GetString(2);
                                temp["email"] = reader.GetString(3);
                                temp["firstName"] = reader.GetString(4);
                                temp["lastName"] = reader.GetString(5);
                                temp["dob"] = reader.GetDateTime(6).ToString();
                                // Process the data (print to console in this example)

                                listOfDictionaries.Add(temp);
                            }

                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }

                        return listOfDictionaries;
                    }
                }
            }
        }
        public static Dictionary <string,string> fetchSpecificUser(int id)
        {
            Dictionary<string,string> mydict = new Dictionary<string,string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("select * from users where UserID = @id", connection))
                {
                    command.Parameters.AddWithValue("id", id);

                    // Execute the query and get a SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        // Check if there are rows in the result set
                        if (reader.HasRows)
                        {


                            // Iterate through the rows
                            while (reader.Read())
                            {
                                Dictionary<string, string> temp = new Dictionary<string, string>();
                                // Access data using column names or indices
                                temp["userId"] = reader.GetInt32(0).ToString();
                                temp["username"] = reader.GetString(1);
                                temp["password"] = reader.GetString(2);
                                temp["email"] = reader.GetString(3);
                                temp["firstName"] = reader.GetString(4);
                                temp["lastName"] = reader.GetString(5);
                                temp["dob"] = reader.GetDateTime(6).ToString();
                                // Process the data (print to console in this example)
                                mydict = temp;
                            }

                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }

                        return mydict;
                    }


                }
                 }


        }
        public static void insertUser(string newUsername, string newPassword, string newEmail, string newFirstName, string newLastName, string newDateOfBirth)
        {
            string insertQuery = "insert into users values(" +
                             "@Username," +
                             "@Password, " +
                             "@Email, " +
                             "@FirstName, " +
                             "@LastName, " +
                             "@DateOfBirth)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SQL query
                        command.Parameters.AddWithValue("@Username", newUsername);
                        command.Parameters.AddWithValue("@Password", newPassword);
                        command.Parameters.AddWithValue("@Email", newEmail);
                        command.Parameters.AddWithValue("@FirstName", newFirstName);
                        command.Parameters.AddWithValue("@LastName", newLastName);
                        command.Parameters.AddWithValue("@DateOfBirth", newDateOfBirth);

                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();
                       
                    }
                }
            }
        public static void updateUser(int userId, string newUsername, string newPassword, string newEmail, string newFirstName, string newLastName, string newDateOfBirth)
        {
            string updateQuery = "UPDATE users " +
                             "SET Username = @Username, " +
                             "    Password = @Password, " +
                             "    Email = @Email, " +
                             "    FirstName = @FirstName, " +
                             "    LastName = @LastName, " +
                             "    DateOfBirth = @DateOfBirth " +
                             "WHERE UserId = @UserId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Add parameters to the SQL query
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Username", newUsername);
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@Email", newEmail);
                    command.Parameters.AddWithValue("@FirstName", newFirstName);
                    command.Parameters.AddWithValue("@LastName", newLastName);
                    command.Parameters.AddWithValue("@DateOfBirth", newDateOfBirth);

                    // Execute the SQL command
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
        public static Dictionary<string,string> fetchUserByUsername(string username)
        {
            Dictionary<string, string> mydict = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM users WHERE username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                            Dictionary<string, string> temp = new Dictionary<string, string>();
                            // Access data using column names or indices
                            temp["userId"] = reader.GetInt32(0).ToString();
                            temp["username"] = reader.GetString(1);
                            temp["password"] = reader.GetString(2);
                            temp["email"] = reader.GetString(3);
                            temp["firstName"] = reader.GetString(4);
                            temp["lastName"] = reader.GetString(5);
                            temp["dob"] = reader.GetDateTime(6).ToString();
                            // Process the data (print to console in this example)
                            mydict = temp;
                            }
                        }
                    }
                }
            
            return mydict;
        }
        public static bool validateEmail(string email)
        {
            // Define a regular expression pattern for a basic email format
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Use Regex.IsMatch to check if the email matches the pattern
            return Regex.IsMatch(email, emailPattern);
        }
        public static bool validateUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkUsernameQuery = "SELECT COUNT(*) FROM users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(checkUsernameQuery, connection))
                {
                    // Add parameter to the SQL query
                    command.Parameters.AddWithValue("@Username", username);

                    // Execute the SQL command and get the result
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        public static List<Language>  fetchLeanringLanguages()
        {
             List<Language> listOfLanguages = new List<Language>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Language.LanguageID,Language.Name,Language.code FROM userLearning left join Language on Language.LanguageID = userLearning.LanguageID WHERE UserID = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", stateManager);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming the language is stored in a column named 'Language'
                            Language temp = new Language(int.Parse(reader["LanguageID"].ToString()), reader["Name"].ToString(), reader["Code"].ToString());
                            listOfLanguages.Add(temp);
                            
                        }
                    }
                }
            }


            return listOfLanguages;
        }
        public static void DeleteuserLearning(int id)
        {
            string updateQuery = "delete from userlearning where LanguageID=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Add parameters to the SQL query
                    command.Parameters.AddWithValue("@id", id);

                    // Execute the SQL command
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
        public static List<Language> fetchAllLanguagesThatIDontLearn(int id)
        {
            List<Language> listOfLanguages = new List<Language>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "select * from language where LanguageID not in(select LanguageID from userLearning where UserID=@id)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming the language is stored in a column named 'Language'
                            Language temp = new Language(int.Parse(reader["LanguageID"].ToString()), reader["Name"].ToString(), reader["Code"].ToString());
                            listOfLanguages.Add(temp);

                        }
                    }
                }
            }


            return listOfLanguages;
        }
        public static void insertuserLearning(int langid)
        {
            string insertQuery = "insert into userLearning values (@uid,@lid)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Add parameters to the SQL query
                    command.Parameters.AddWithValue("@uid", stateManager);
                    command.Parameters.AddWithValue("@lid", langid);


                    // Execute the SQL command
                    int rowsAffected = command.ExecuteNonQuery();

                }
            }
        }
        public static List<Course> fetchCourseByLanguage(int langid)
        {
            List<Course> listOfCourses = new List<Course>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * from Course where LanguageID = @langid order by Level";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@langid", langid);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming the language is stored in a column named 'Language'
                            Course temp = new Course(int.Parse(reader["CourseID"].ToString()), reader["Title"].ToString(), reader["Description"].ToString(), int.Parse(reader["LanguageID"].ToString()), int.Parse(reader["Level"].ToString()), float.Parse(reader["price"].ToString()));
                            listOfCourses.Add(temp);

                        }
                    }
                }
            }
            return listOfCourses;
        }
        public static List<Question> fetchQuestionByCourse(int courseId)
        {
            List <Question> listOfQuestions = new List<Question>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT top 10 * from Questions where CourseID = @CID order by NEWID()";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CID", courseId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming the language is stored in a column named 'Language'
                            Question temp = new Question(int.Parse(reader["QuestionID"].ToString()), reader["Question"].ToString(), reader["answer"].ToString(), int.Parse(reader["CourseID"].ToString())) ;
                            listOfQuestions.Add(temp);

                        }
                    }
                }
            }


            return listOfQuestions;
        }
        public static UserStats fetchUserStats()
        {
            UserStats user  = null;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * from UserStats where UserID = @userid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userid", stateManager);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            user = new UserStats(int.Parse(reader["StatID"].ToString()), int.Parse(reader["UserID"].ToString()), int.Parse(reader["level"].ToString()), int.Parse(reader["TotalPoints"].ToString()));
                            return user;

                        }
                    }
                }
            }
            return user;
        }
        public static void updateUserStats(int id,int points)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "changeLevelProc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@points", points);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
