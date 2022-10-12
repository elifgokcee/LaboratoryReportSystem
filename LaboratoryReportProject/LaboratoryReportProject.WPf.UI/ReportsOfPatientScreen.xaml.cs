using LaboratoryReportProject.Business.Abstracts;
using LaboratoryReportProject.Entities;
using LaboratoryReportProject.Entities.ComplexTypes;
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
using System.Windows.Shapes;

namespace LaboratoryReportProject.WPf.UI
{
    /// <summary>
    /// Interaction logic for ReportsOfPatientScreen.xaml
    /// </summary>
    public partial class ReportsOfPatientScreen : Window
    {
        public ReportsOfPatientScreen()
        {
            InitializeComponent();
        }
        public ReportService _reportService;
        public int _patientId;
        public int _laborantId;
        public int _diagnosisId;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            reportsOfPatientdgw.ItemsSource = _reportService.GetReportDetailsByPatientId(_patientId);
        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            ReportDetails row_selected = reportsOfPatientdgw.SelectedItem as ReportDetails;
            if (MessageBox.Show("Delete report?", "No delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                
            }
            else
            {
             
                if (row_selected != null)
                {
                    bool result = _reportService.Delete(Convert.ToInt32(row_selected.Id));
                    if (result)
                    {
                        MessageBox.Show("Deleted");
                        reportsOfPatientdgw.ItemsSource = _reportService.GetReportDetailsByPatientId(_patientId);
                    }
                    else
                    {
                        MessageBox.Show("Couldn't delete");
                    }



                }
            }
        
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            ReportDetails row_selected = reportsOfPatientdgw.SelectedItem as ReportDetails;
            if (row_selected != null)
            {
                UpdateReportScreen updateReportScreen = new UpdateReportScreen();

                updateReportScreen.LaborantName = row_selected.LaborantName;
                updateReportScreen.PatientNameAndSurname = row_selected.PatientName;
                updateReportScreen.PatientIdentity = row_selected.PatientIdentityNumber;
                updateReportScreen.reportId = row_selected.Id;
                updateReportScreen.CreatedDate = row_selected.CreatedDate;
                updateReportScreen.DiagnosisTitle = row_selected.DiagnosisTitle;
                updateReportScreen.DiagnosisDescription = row_selected.DiagnosisDescription;
                updateReportScreen._reportService = _reportService;
                updateReportScreen.PatientId = _patientId;
                updateReportScreen.LaborantId = _laborantId;
                updateReportScreen.ShowDialog();
              
             

            }
            reportsOfPatientdgw.ItemsSource = _reportService.GetReportDetailsByPatientId(_patientId);

        }

    }
}
