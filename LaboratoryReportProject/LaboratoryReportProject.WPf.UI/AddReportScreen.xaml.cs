using LaboratoryReportProject.Business.Abstracts;
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
    /// Interaction logic for AddReportScreen.xaml
    /// </summary>
    public partial class AddReportScreen : Window
    {
        public ReportService _reportService;
        public DiagnosisService _diagnosisService;
        public AddReportScreen()
        {
            InitializeComponent();
            _diagnosisService=InstanceFactory.GetInstance<DiagnosisService>();  
        }

        public string LaborantName { get; set; }
        public int LaborantId { get; set; }
        public int PatientId { get; set; }
        public string PatientIdentity { get; set; }    
        public string PatientNameAndSurname { get; set; }   
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            patientNameandSurnameTbx.Text = PatientNameAndSurname;
            patientIdentityTbx.Text = PatientIdentity;
            laborantNameTbx.Text= LaborantName;
            createdDatetbx.Text = DateTime.Now.ToString(); 


        }

        private void addReportButton_Click(object sender, RoutedEventArgs e)
        {
            if (diagnosisDescriptionTbx.Text == "" || diagnosisTitleTbx.Text == "")
            {
                MessageBox.Show("Please complete all required fields");
            }
            else
            {
                try
                {
                    Diagnosis _diagnosis = new Diagnosis {
                        Id=_diagnosisService.GetLastId()+1,   
                        DiagnosisName = diagnosisDescriptionTbx.Text,
                        Title=diagnosisTitleTbx.Text,
                        
                        
                        };
                    _diagnosisService.Add(_diagnosis);
           
                    _reportService.Add(new Entities.Report
                    {
                        CreatedDate = Convert.ToDateTime(createdDatetbx.Text),
                        PatientId = PatientId,
                        LaborantId = LaborantId,
                        DiagnosisId = _diagnosis.Id

                    } );
                    MessageBox.Show("Added");
                    this.Close();
                }
                catch(Exception ex) 
                {
                    throw new Exception(ex.Message);
                   

                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {this.Close();

        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
