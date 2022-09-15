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
                for (int i = 0; i < AddNewModulePage.ModuleList.Count; i++)
                {
                    //Borders for each project
                    var border = new Border {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(2,2,2,2) , 
                        Margin = new Thickness(5,5,5,5),
                        CornerRadius = new CornerRadius(5)
                    };
                    var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
                    //make border parent to scope the stack pannel
                    border.Child = stackPanel;
                    stackPanel.Children.Add(new Label { Content = AddNewModulePage.ModuleList[i].ModuleCode });
                    stackPanel.Children.Add(new Label { Content = AddNewModulePage.ModuleList[i].ModuleName });

                    grModuleListing.Children.Add(border);
                    Grid.SetColumn(border, 1);
                    Grid.SetRow(border, i+2);

                }

                
            }

        }
    }
}
