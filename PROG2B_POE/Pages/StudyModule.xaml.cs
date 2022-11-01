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
        public static List<Logs> StudyLogs = new List<Logs>();
        public StudyModule()
        {
            InitializeComponent();
            cmbModuleDropDown.ItemsSource = AddNewModulePage.ModuleCodes;
            txtStudyHours.IsEnabled = false;
            btnSave.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dtStudydate.SelectedDate.Value == null)
                {
                    throw new Exception("Error : Date is invalid");  
                }
                double previousValue = StudyhrsSave[cmbModuleDropDown.SelectedIndex];
                double newhr = previousValue + Double.Parse(txtStudyHours.Text);

                StudyhrsSave[cmbModuleDropDown.SelectedIndex] = newhr;
                StudyLogs.Add(new Logs {
                   ModuleCode = AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].ModuleCode,
                   Studydate = dtStudydate.SelectedDate.Value,
                   Studyhrs = Double.Parse (txtStudyHours.Text),
                   ModuleName = AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].ModuleName
                });
                txtStudyHours.Clear();
            }
            catch (Exception ez)
            {

                MessageBox.Show("Error : " + ez.Message);
            }

        }

        private void cmbModuleDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtStudyHours.IsEnabled = true;
            btnSave.IsEnabled = true;
        }
    }
}
