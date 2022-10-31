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
            MainWindow mainWindowOBJ = new MainWindow();
            mainWindowOBJ.Show();
            this.Close();
        }
    }
}
