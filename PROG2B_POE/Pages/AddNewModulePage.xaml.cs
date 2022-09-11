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
    /// Interaction logic for AddNewModulePage.xaml
    /// </summary>
    public partial class AddNewModulePage : Page
    { 
        public static List<Projects> ModuleList = new List<Projects>();
        public AddNewModulePage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ModuleList.Add(new Projects { 
                ModuleCode = txtModuleCode.Text,
                ModuleName = txtModuleName.Text
            
            });

        }
    }

    public class Projects {
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
    }
}
