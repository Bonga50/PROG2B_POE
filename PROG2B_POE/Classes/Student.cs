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
        public List<Pages.Projects> GetModules()
        {
            string text = $"select ModuleCode,ModuleName,NumOfCredits,HoursPerWeek,SemesterStartDate,SemesterWeeks from Module;";
            List<Pages.Projects> result = new List<Pages.Projects>();

            using (conn)
            {
                conn.Open();
                DataTable tap = new DataTable();
                new SqlDataAdapter(text, conn).Fill(tap);
               
                result = tap.Rows.OfType<DataRow>().Select(dr => dr.Field<Pages.Projects>("ModuleCode")).ToList();
            }
            return result;


        }

    }
}
