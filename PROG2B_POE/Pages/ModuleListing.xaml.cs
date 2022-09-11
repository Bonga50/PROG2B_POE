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
    /// Interaction logic for ModuleListing.xaml
    /// </summary>
    public partial class ModuleListing : Page
    {
        public ModuleListing()
        {
            InitializeComponent();
            ListSearch();
        }

        private void ListSearch() {
            if (AddNewModulePage.ModuleList.Count > 0)
            {


                var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
                stackPanel.Children.Add(new Label { Content = AddNewModulePage.ModuleList[0].ModuleCode });
                stackPanel.Children.Add(new Label { Content = AddNewModulePage.ModuleList[0].ModuleName });

                grModuleListing.Children.Add(stackPanel);
                Grid.SetColumn(stackPanel, 1);
                Grid.SetRow(stackPanel, 2);
            }

        }
    }
}
