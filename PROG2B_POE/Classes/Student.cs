using System.Data.SqlClient;

namespace PROG2B_POE.Classes
{
    class Student
    {
        /// <summary>
        /// This method will confirm the users details of the user who is loging in 
        /// will be used in register-login class
        /// Each user wil have 
        /// Username = StudentID
        /// Name = Name
        /// Password = Password
        /// </summary>
        SqlConnection conn = Connection.GetConeection();
        public string StudentID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        //Student constuctor
        public Student() { }

        public Student(string Studentnum, string name, string password)
        {
            StudentID = Studentnum;
            Password = password;
            Name = name;
        }

        //verifying login for student
        public void getStudent(string Studentnum)
        {
            string text = $"select * from Student where StudentId = '{Studentnum}'";

            using (conn)
            {
                SqlCommand cmdSelect = new SqlCommand(text, conn);
                conn.Open();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StudentID = (string)reader[0];
                        Password = (string)reader[1];
                        Name = (string)reader[2];

                    }
                }
                conn.Close();
            }


        }

        //New student sign uo
        public void createtStudent(string Username, string Password, string Name)
        {

            string text = $"insert into Student values('{Username}','{Password}','{Name}');";
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(text, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
        }
    }
}
