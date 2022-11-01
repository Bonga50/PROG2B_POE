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
    /// Interaction logic for SignUpPg.xaml
    /// </summary>
    public partial class SignUpPg : Window
    {
        public SignUpPg()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            Register_Login register_LoginOBJ = new Register_Login();
            register_LoginOBJ.Show();
            this.Close();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            string UserId = txtUsername.Text;
            string password = txtPassword.Password.ToString();
            string Name = txtFirstName.Text;
            //Hashing the password
            string hashedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            try
            {
                Classes.Student stuOBJ = new Classes.Student();
                stuOBJ.createtStudent(UserId, hashedPassword, Name);
                MessageBox.Show("Succesful sign up, please log in");
                Clearboxes();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);

            }
            

        }

        private void Clearboxes() {
            txtFirstName.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
