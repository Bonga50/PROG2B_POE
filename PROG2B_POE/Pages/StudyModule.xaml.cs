using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PROG2B_POE.Pages
{
    /// <summary>
    /// Interaction logic for StudyModule.xaml
    /// </summary>
    public partial class StudyModule : Page
    {
        
        public static List<Logs> StudyLogs = new List<Logs>();
        public StudyModule()
        {
            InitializeComponent();
            cmbModuleDropDown.ItemsSource= AddNewModulePage.ModuleCodes;
            txtStudyHours.IsEnabled = false;
            btnSave.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.Student em = new Classes.Student();
                //error handleing
                if (dtStudydate.SelectedDate.Value == null || dtStudydate.SelectedDate.Value < 
                    AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].SemesterStartDate||
                    dtStudydate.SelectedDate.Value > 
                    AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].SemesterStartDate.AddDays
                    (AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].SemesterWeeks*7))
                {
                    throw new Exception("Error : Date is invalid");
                }
                //study hrs control
                 
                //StudyLogs.Add(new Logs
                //{
                //    ModuleCode = AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].ModuleCode,
                //    Studydate = dtStudydate.SelectedDate.Value,
                //    Studyhrs = Double.Parse(txtStudyHours.Text),
                //    ModuleName = AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].ModuleName,
                //    UserName= Register_Login.userNameIX,
                //    Weeks = trackWeek(
                //        dtStudydate.SelectedDate.Value,
                //        AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].SemesterStartDate,
                //        AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].SemesterStartDate.AddDays(7),
                //        cmbModuleDropDown.SelectedIndex)
                //});

                em.CreateLog(
                    Register_Login.userNameIX,
                    AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].ModuleCode,
                    dtStudydate.SelectedDate.Value,
                    Double.Parse(txtStudyHours.Text),
                    AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].ModuleName,
                    trackWeek(
                        dtStudydate.SelectedDate.Value,
                        AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].SemesterStartDate,
                        AddNewModulePage.ModuleList[cmbModuleDropDown.SelectedIndex].SemesterStartDate.AddDays(7),
                        cmbModuleDropDown.SelectedIndex)
                    );
                
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

        //this will keep track of what week the user chooses to study in
        public string trackWeek(DateTime studyDate, DateTime weekStartDate, DateTime weekEndDate, int index)
        {
            string week = "";
            DateTime tempweekStartDate = weekStartDate;
            DateTime tempweekEndDate = weekEndDate;

            for (int i = 0; i < AddNewModulePage.ModuleList[index].SemesterWeeks; i++)
            {
                if (studyDate > tempweekStartDate && studyDate < tempweekEndDate)
                {
                    week = "week " + (i + 1);
                    break;
                }
                else
                {
                    tempweekStartDate = tempweekEndDate;
                    tempweekEndDate = tempweekStartDate.AddDays(7);
                }

            }
            return week;
        }
        public double getWeeklyRemaining(DateTime studyDate, DateTime weekStartDate, DateTime weekEndDate, int index,double studyhrs) {
            double hrsReamin = 0;
            for (int i = 0; i < AddNewModulePage.ModuleList[index].SemesterWeeks; i++)
            {

            }
            return hrsReamin;
        }
    }
}
