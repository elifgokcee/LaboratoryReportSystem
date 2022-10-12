using LaboratoryReportProject.Business.Abstracts;
using LaboratoryReportProject.Business.Concrete;
using LaboratoryReportProject.Business.DependencyResolvers.Ninject;
using LaboratoryReportProject.Entities;
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
    /// Interaction logic for UpdateReportScreen.xaml
    /// </summary>
    public partial class UpdateReportScreen : Window
    {
        public UpdateReportScreen()
        {
            InitializeComponent();
            _diagnosisService=InstanceFactory.GetInstance<DiagnosisService>();  
        }
        public string LaborantName { get; set; }
        public int LaborantId { get; set; }
        public int PatientId { get; set; }
        public int DiagnosisId { get; set; }    
        public string PatientIdentity { get; set; }
        public string PatientNameAndSurname { get; set; }
        public DateTime CreatedDate { get; set; }
        public int reportId { get; set; }   
        public string DiagnosisDescription { get;set; }
        public string DiagnosisTitle { get; set; }  
        private DiagnosisService _diagnosisService;
        public ReportService _reportService;   

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();    

        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {

            WindowState = WindowState.Minimized;
        }

        private void updateReportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Diagnosis diagnosis = new Diagnosis();
                diagnosis.Id = _diagnosisService.GetLastId() + 1;
                diagnosis.Title = diagnosisTitleTbx.Text;
                diagnosis.DiagnosisName = diagnosisDescriptionTbx.Text;
                _diagnosisService.Add(diagnosis);
                _reportService.Update(new Entities.Report
                {
                    Id = reportId,
                    CreatedDate = DateTime.Now,
                    LaborantId = LaborantId,
                    PatientId = PatientId,
                    DiagnosisId  = diagnosis.Id,

                });
                MessageBox.Show("Updated");
                
                this.Close();
            }
            catch {
                MessageBox.Show("Couldn't update");
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            patientIdentityTbx.Text = PatientIdentity;
            patientNameandSurnameTbx.Text = PatientNameAndSurname;
            laborantNameTbx.Text = LaborantName;
            createdDatetbx.Text = CreatedDate.ToString();
            diagnosisDescriptionTbx.Text = DiagnosisDescription;
            diagnosisTitleTbx.Text = DiagnosisTitle;

        }
    }
}
