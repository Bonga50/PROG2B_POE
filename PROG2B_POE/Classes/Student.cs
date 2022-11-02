using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
        //method used to add new module
        public void AddNewModule(
            string Username,
            string ModuleCode,
            string ModuleName,
            int Credits,
            int hrsPerWeek,
            DateTime Semesterstart,
            int Weeks

            )
        {
            string text = $"insert into Module values('{ModuleCode}','{ModuleName}',{Credits},{hrsPerWeek},'{Semesterstart}','{Weeks}','{Username}');";
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(text, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }

        }
        //mehod used to get module data
        //https://www.youtube.com/watch?v=F6dkjsmuw6I
        public List<Pages.Projects> GetModules(string userId)
        {
            string text = $@"select ModuleCode as ModuleCode
            ,ModuleName as ModuleName
            ,NumOfCredits as NumOfCredits
            ,HoursPerWeek as HoursPerWeek
            ,SemesterStartDate as SemesterStartDate
            ,SemesterWeeks as SemesterWeeks
            ,Username as Username
            from Module where Username = '{userId}';";
            List<Pages.Projects> Proj = null;

            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(text,conn);
                var dataRead = cmd.ExecuteReader();
                Proj = getList<Pages.Projects>(dataRead);
               
            }
            return Proj;

        }

        public List<T> getList<T>(IDataReader Reader){
            List<T> lst = new List<T>();
            while (Reader.Read())
            {
                var type = typeof(T);
                T obj = (T)Activator.CreateInstance(type);
                foreach (var item in type.GetProperties())
                {
                    var propType = item.PropertyType;
                    item.SetValue(obj, Convert.ChangeType( Reader[item.Name].ToString(),propType));
                }
                lst.Add(obj);
            }
            return lst;
        
        }
        //Method to create a study log every time the user studies
        public void CreateLog(
            string Username,
            string ModuleCode,
            DateTime Studydate,
            double studyhrs,
            string ModuleName,
            string weeks
            ) {
            string text = $"insert into StudyLogger values('{Username}','{Studydate}',{studyhrs},'{ModuleName}','{ModuleCode}','{weeks}');";
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(text, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
        }

        public void getStudyWeek(string username) { }
        public List<String> getCodes(string username) {
            string text = $@"select ModuleCode as ModuleCode from Module where Username = '{username}';";
            List<String> Proj = new List<string>() ;


            using (conn)
            {
                SqlCommand cmdSelect = new SqlCommand(text, conn);
                conn.Open();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Codes = (string)reader[0];
                        Proj.Add(Codes);
                    }
                }
                conn.Close();
            }
            return Proj;

        }



    }
}
