using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PROG2B_POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pages.AddNewModulePage pgAddMod = new Pages.AddNewModulePage();
        Pages.ModuleListing pgListMod = new Pages.ModuleListing();

        public MainWindow()
        {

            InitializeComponent();
            FrmNav.Content = pgListMod;
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrmNav.Content = pgAddMod;
        }

        private void btnModuleListing_Click(object sender, RoutedEventArgs e)
        {
            Pages.ModuleListing pgListMod = new Pages.ModuleListing();
            FrmNav.Content = pgListMod;
        }

        private void btnStudyModule_Click(object sender, RoutedEventArgs e)
        {
            Pages.StudyModule pgStudy = new Pages.StudyModule();
            FrmNav.Content = pgStudy;
        }

 

        private void btnLogs_Click(object sender, RoutedEventArgs e)
        {
            Pages.StudyLogger pgLogger = new Pages.StudyLogger();
            FrmNav.Content = pgLogger;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            //https://www.c-sharpcorner.com/UploadFile/mahesh/messagebox-in-wpf/

            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to close this window?",
            "LogOut", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Register_Login register_LoginOBJ = new Register_Login();
                register_LoginOBJ.Show();
                this.Close();

            }

        }

       

        private void LoadedUser(object sender, RoutedEventArgs e)
        {
            Classes.Student em = (Classes.Student)this.Tag;
            this.Title = $"Welcome {em.Name}: ({em.StudentID})";
            
    }
    }
}
