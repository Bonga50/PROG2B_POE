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


            ////Button btnTemp = new Button();
            ////btnTemp.Background = Brushes.Red;
            ////btnTemp.BorderBrush = Brushes.Black;

            ////var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
            ////stackPanel.Children.Add(new Label { Content = "ModuleName" });
            ////stackPanel.Children.Add(new Button { Content = "Button" });

            ////MainGrid.Children.Add(stackPanel);
            //////MainGrid.Children.Add(btnTemp);
            ////Grid.SetColumn(stackPanel, 3);
            ////Grid.SetRow(stackPanel, 2);
        }

        private void btnModuleListing_Click(object sender, RoutedEventArgs e)
        {
            Pages.ModuleListing pgListMod = new Pages.ModuleListing();
            FrmNav.Content = pgListMod;
        }
    }
}
