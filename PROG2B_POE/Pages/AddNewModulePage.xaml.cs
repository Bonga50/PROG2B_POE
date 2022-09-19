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
using ProjectModule;

namespace PROG2B_POE.Pages
{
    /// <summary>
    /// Interaction logic for AddNewModulePage.xaml
    /// </summary>
    public partial class AddNewModulePage : Page
    {
        public static List<Projects> ModuleList = new List<Projects>();
        //A parralel list that holds the study hours
        public static List<Double> StudyHrs = new List<Double>();
        //Name of modules in list, this will be used to view modules in study option
        public static List<String> ModuleNames = new List<String>();
        public static List<weekTrack> TrackWeek = new List<weekTrack>();
        public AddNewModulePage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            //Errorhandling
            try
            {
                if (dpStartDate.SelectedDate.Value > dpEndDate.SelectedDate.Value)
                {
                    throw new Exception("Strart date can not be after end date");
                }

                if (ModuleList.Exists(x => x.ModuleCode == txtModuleCode.Text)) {
                    throw new Exception("Project already exists");
                }

                ModuleList.Add(new Projects
                {
                    ModuleCode = txtModuleCode.Text,
                    ModuleName = txtModuleName.Text,
                    NumOfCredits = Int32.Parse(txtNumOfCredits.Text),
                    HoursPerWeek = double.Parse(txtHrsPerWeek.Text),
                    SemesterStartDate = dpStartDate.SelectedDate.Value,
                    SemesterEndDate = dpEndDate.SelectedDate.Value

                });

                ModuleNames.Add(txtModuleName.Text);
                StudyModule.StudyhrsSave.Add(0);

                TrackWeek.Add(new weekTrack
                {
                    ModuleCode = txtModuleCode.Text,
                    TheSetDate = DateTime.Today
                });



            }
            catch (Exception ez)
            {

                MessageBox.Show("Error : " + ez.Message);
            }
            

        }
    }

    public class Projects {
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int NumOfCredits { get; set; }
        public double HoursPerWeek { get; set; }
        public DateTime SemesterStartDate { get; set; }
        public DateTime SemesterEndDate { get; set; }

    }

    public class weekTrack{
       public DateTime TheSetDate { get; set; }
       public String ModuleCode { get; set; }

    }
}
