using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        private void ListSearch()
        {

            //Object to call class library methods.
            ProjectModule.TheStudyClass prog = new ProjectModule.TheStudyClass();


            if (AddNewModulePage.ModuleList.Count > 0)
            {
                //will itarate the list and create new wpf elements based on how many items are stored in the list
                for (int i = 0; i < AddNewModulePage.ModuleList.Count; i++)
                {
                    //method call to calculte self study hours 

                    double SelfStudy = prog.SelfStudy(
                        AddNewModulePage.ModuleList[i].NumOfCredits,
                        AddNewModulePage.ModuleList[i].SemesterStartDate,
                        AddNewModulePage.ModuleList[i].SemesterWeeks,
                        AddNewModulePage.ModuleList[i].HoursPerWeek
                        );
                    double TotalSelfStudy = prog.TotalhrsPreMod(
                      AddNewModulePage.ModuleList[i].NumOfCredits,
                      AddNewModulePage.ModuleList[i].SemesterStartDate,
                      AddNewModulePage.ModuleList[i].SemesterWeeks,
                      AddNewModulePage.ModuleList[i].HoursPerWeek
                      );
                    //method to Check if a week has passed
                    dateTracker(i);
                    //will calculate the remaining hours weekly and total

                    double remainingself = SelfStudy - StudyModule.StudyhrsSave[i];
                    double totalremaining = TotalSelfStudy - StudyModule.StudyhrsSave[i];
                    //if statment to check if the user has enough for the week
                    if (StudyModule.StudyhrsSave[i] >= SelfStudy)
                    {
                        remainingself = 0;
                    }
                    //if statemnt to check if user has studied enough for semester 
                    if (StudyModule.StudyhrsSave[i] >= TotalSelfStudy)
                    {
                        totalremaining = 0;
                    }
                    dateTracker(i);


                    //Borders for each project
                    var border = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(2, 2, 2, 2),
                        Margin = new Thickness(5, 5, 5, 5),
                        CornerRadius = new CornerRadius(5)
                    };
                    //new stack panel that will be used as a template for every new item created
                    var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
                    //make border parent to scope the stack pannel
                    border.Child = stackPanel;
                    stackPanel.Children.Add(new Label
                    {
                        Content =
                        "Code: "+AddNewModulePage.ModuleList[i].ModuleCode+"\t\t\t\t\t"+ "\n" +
                        "Weekly hrs :  "+StudyModule.StudyhrsSave[i] + " / " + String.Format("{0:0.00}", SelfStudy) + "\n" +
                        "Semester hrs:   "+StudyModule.StudyhrsSave[i] + " / " + String.Format("{0:0.00}", TotalSelfStudy)+"\n"+
                        "Name: " + AddNewModulePage.ModuleList[i].ModuleName + "\n" +
                        "Remaining weekly hrs: "+String.Format("{0:0.00}", remainingself) + " remaining" + "\n" +
                        "Semester hrs:  "+String.Format("{0:0.00}", totalremaining) + " remaining"+ "\n" +
                        "Number of credits: " + AddNewModulePage.ModuleList[i].NumOfCredits + "\n" +
                        "Class hrs: " + AddNewModulePage.ModuleList[i].HoursPerWeek + "\n" +
                        "Start Date: " + AddNewModulePage.ModuleList[i].SemesterStartDate+ "\n" +
                        "Weeks: " + AddNewModulePage.ModuleList[i].SemesterWeeks
                    });

                    grdInnerGrid.Children.Add(border);
                    Grid.SetColumn(border, 1);
                    Grid.SetRow(border, i + 2);
                    Grid.SetColumnSpan(border, 6);

                }

            }

        }

        public void dateTracker(int i)
        {
            DateTime Currntdate = AddNewModulePage.TrackWeek[i].TheSetDate;
            DateTime newdate = DateTime.Now;
            newdate = Currntdate.AddDays(7);

            if (Currntdate == newdate)
            {
                MessageBox.Show("weekly reset is" + newdate.Date);
                AddNewModulePage.TrackWeek[i].TheSetDate = newdate;
                StudyModule.StudyhrsSave[i] = 0;

            }



        }
    }
}
