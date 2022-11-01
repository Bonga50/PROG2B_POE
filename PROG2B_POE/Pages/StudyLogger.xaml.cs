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
    /// Interaction logic for StudyLogger.xaml
    /// </summary>
    public partial class StudyLogger : Page
    {
        List<Logs> tempLogs = new List<Logs>();
         public StudyLogger()
        {
            InitializeComponent();
            populateLogs();
            cmbLogg.ItemsSource = AddNewModulePage.ModuleCodes;
        }


        private void populateLogs() {
            tempLogs = StudyModule.StudyLogs.OrderBy(x => x.Studyhrs).ToList();
            dtStudyLogger.ItemsSource = tempLogs;
        }

        private void cmbLogg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            tempLogs = StudyModule.StudyLogs.Where(x => x.ModuleCode == AddNewModulePage.ModuleList[cmbLogg.SelectedIndex].ModuleCode ).ToList();
            dtStudyLogger.ItemsSource = tempLogs;

        }

        private void btnViewall_Click(object sender, RoutedEventArgs e)
        {
            populateLogs();
        }
    }

    public class Logs {
        
        public DateTime Studydate { get; set; }
        public double Studyhrs { get; set; }
        public double remaininghrs { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public string Weeks { get; set; }
        public string UserName { get; set; }
    }
}
