using LaboratoryReportProject.Business.Abstracts;
using LaboratoryReportProject.Business.Auth;
using LaboratoryReportProject.Business.DependencyResolvers.Ninject;
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
    /// Interaction logic for PatientsDetailsScreen.xaml
    /// </summary>
    public partial class PatientsDetailsScreen : Window
    {
        public PatientsDetailsScreen()
        {
            InitializeComponent();
            _diagnosisService=InstanceFactory.GetInstance<DiagnosisService>();  
          
        }
        public PatientService _patientService;
        public ReportService _reportService;
        private DiagnosisService _diagnosisService;
        public int Id { get; set; } 
        public string IdentityNumber { get; set; }  

        public string PatientSurname { get; set; }  
        public string PatientName { get; set; } 
        public string BirthDate { get; set; }   
     

        public Session _session;
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            
            patientIdentityTbx.Text = IdentityNumber;
            patientNameTbx.Text = PatientName;
            patientSurnameTbx.Text = PatientSurname;
            birthDateTbx.Text = BirthDate;

        }
      

        private void addReportButton_Click(object sender, RoutedEventArgs e)
        {
            AddReportScreen addReportScreen=new AddReportScreen();
            addReportScreen.LaborantId = _session.LaborantId;
            addReportScreen.LaborantName=_session.LaborantNameAndSurname;
            addReportScreen.PatientIdentity = IdentityNumber;
            addReportScreen.PatientNameAndSurname = PatientName + "  " + PatientSurname;
            addReportScreen._reportService = _reportService;
            addReportScreen.PatientId = Id;
            addReportScreen.ShowDialog();
           
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            
          this.Close();
           

        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void getReportsButton_Click(object sender, RoutedEventArgs e)
        {
            ReportsOfPatientScreen reportsOfPatientScreen = new ReportsOfPatientScreen();
            reportsOfPatientScreen._patientId = Id;
            reportsOfPatientScreen._reportService = _reportService;
            reportsOfPatientScreen._laborantId = _session.LaborantId;
          
            reportsOfPatientScreen.ShowDialog();
        }
       

        private void Window_Closed(object sender, EventArgs e)
        {
           
        }

        private void deletePatientsButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Delete patient?", "No delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {

            }
            else
            {
                List<ReportDetails> list= _reportService.GetReportDetailsByPatientId(Id);
                foreach (ReportDetails reportDetails in list)
                {
                    _diagnosisService.Delete(_reportService.GetById(reportDetails.Id).DiagnosisId);
                }

                bool resultReport = _reportService.DeleteReportByPateientId(Id);
                bool result = _patientService.Delete(Id);
                    if (result&& resultReport)
                    {
                        MessageBox.Show("Deleted");
                    Close();
                    }
                    else
                    {
                        MessageBox.Show("Couldn't delete");
                    }



                
            }
        }
    }
}
