using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROG2B_POE
{
    /// <summary>
    /// Interaction logic for Register_Login.xaml
    /// </summary>
    public partial class Register_Login : Window
    {
        //username that will be used in all classes
        public static string userNameIX;
        public Register_Login()
        {
            InitializeComponent();
            
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            SignUpPg signUpPgOBJ = new SignUpPg();
            signUpPgOBJ.Show();
            this.Close();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string UserId = txtUsername.Text;
            string password = txtPassword.Password.ToString();

            //Student Object
            Classes.Student ST_OBJ = new Classes.Student();
            try
            {

                ST_OBJ.getStudent(UserId);
                //unhashed password
                string unhased = Encoding.UTF8.GetString(Convert.FromBase64String(ST_OBJ.Password));
                //checking if user login details are correct
                if (UserId.Equals(ST_OBJ.StudentID) && password.Equals(unhased))
                {
                    userNameIX = UserId;
                    //creating an instace to call the main page once the user details are verified
                    MainWindow mainWindowOBJ1 = new MainWindow();
                    mainWindowOBJ1.Tag = ST_OBJ; 
                    mainWindowOBJ1.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect password or username");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :"+ex.Message);
               
            }
        }
    }
}
