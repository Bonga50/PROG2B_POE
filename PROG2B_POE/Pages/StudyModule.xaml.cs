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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG2B_POE.Pages
{
    /// <summary>
    /// Interaction logic for StudyModule.xaml
    /// </summary>
    public partial class StudyModule : Page
    {
        public static List<Double> StudyhrsSave = new List<Double>();
        public StudyModule()
        {
            InitializeComponent();
            cmbModuleDropDown.ItemsSource = AddNewModulePage.ModuleNames;
            txtStudyHours.IsEnabled = false;
            btnSave.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double previous = StudyhrsSave[cmbModuleDropDown.SelectedIndex];
                double newhr = previous + Double.Parse(txtStudyHours.Text);


                StudyhrsSave[cmbModuleDropDown.SelectedIndex] = newhr;

                txtStudyHours.Clear();
            }
            catch (Exception)
            {

                throw;
            }


        }

   

        private void cmbModuleDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtStudyHours.IsEnabled = true;
            btnSave.IsEnabled = true;
        }
    }
}
