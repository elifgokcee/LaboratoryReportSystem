using LaboratoryReportProject.Business.Abstracts;
using LaboratoryReportProject.Business.Auth;
using LaboratoryReportProject.Business.DependencyResolvers.Ninject;
using LaboratoryReportProject.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        public LaborantService _laborantService;
        public SessionService sessionService;
        public PatientService _patientservice;
        public ReportService _reportService; 
        public Session _session;
        public HomeScreen()
        {
            InitializeComponent();
            _patientservice = InstanceFactory.GetInstance<PatientService>();
            _reportService=InstanceFactory.GetInstance<ReportService>();    
            sessionService = InstanceFactory.GetInstance<SessionService>(); 
          
        }
        private void getReportsButton_Click(object sender, RoutedEventArgs e)
        {
            patientsdgw.ItemsSource = _reportService.GetReportDetails();
        }
        private void getPatientsButtonClick(object sender, RoutedEventArgs e)
        {
            patientsdgw.ItemsSource = _patientservice.GetAll();
        }
        private void Refresh()
        {
            patientsdgw.ItemsSource = _patientservice.GetAll();
            reportsdgw.ItemsSource = _reportService.GetReportDetails();
        }

        private void patientsdgw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void patientsdgw_MouseDoubleClick(object sender, MouseButtonEventArgs e)
         {PatientsDetailsScreen patientsDetailsScreen = new PatientsDetailsScreen();
            Patient row_selected = patientsdgw.SelectedItem as Patient;
            if (row_selected != null)
            {
                patientsDetailsScreen.Id = row_selected.Id;
                patientsDetailsScreen.IdentityNumber = row_selected.IdentityNumber;
                patientsDetailsScreen.PatientName = row_selected.Name;
                patientsDetailsScreen.PatientSurname = row_selected.SurName;
                patientsDetailsScreen.BirthDate = row_selected.BirthDate.ToString();
                patientsDetailsScreen._session = _session;
                patientsDetailsScreen._reportService = _reportService;
                patientsDetailsScreen._patientService = _patientservice;
                patientsDetailsScreen.ShowDialog();

            }
            Refresh();



        }
      
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            patientsdgw.ItemsSource = _patientservice.GetPatientByIdentityNumber(searchPatientTbx.Text);
        }
        private void searchReportButton_Click(object sender, RoutedEventArgs e)
        {
            reportsdgw.ItemsSource = _reportService.GetReportDetailsByPatientName(searchReportTbx.Text);

        }

        private void searchReportTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

           

            if (String.IsNullOrEmpty(searchReportTbx.Text))
            {
                Refresh();


            }
        }

        private void searchPatientTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(searchPatientTbx.Text, "[a-zA-Z]") || searchPatientTbx.Text.Length > 11)
            {

                searchPatientTbx.Text = searchPatientTbx.Text.Remove(searchPatientTbx.Text.Length - 1);
            }

           if (String.IsNullOrEmpty(searchReportTbx.Text))
            {
                Refresh();

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
            reportsdgw.ItemsSource = _reportService.GetReportDetails();
            if (_session.RoleId == 2)
            {
                addLaborantButton.Visibility = Visibility.Hidden;
            }
        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void buttonRefreshReports_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void buttonRefreshPatients_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

     

        private void addPatientButton_Click(object sender, RoutedEventArgs e)
        {
            AddPatientScreen addPatientScreen = new AddPatientScreen();

            addPatientScreen._patientService = _patientservice;

            addPatientScreen.ShowDialog();
            Refresh();

        }

        private void addLaborantButton_Click(object sender, RoutedEventArgs e)
        {
            AddLaborantScreen addLaborantScreen = new AddLaborantScreen();
            addLaborantScreen._laborantService = _laborantService;
            addLaborantScreen.ShowDialog();

        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            sessionService.DeadSession(_session);
           
            LoginScreen loginScreen = new LoginScreen();
            this.Close();
            loginScreen.ShowDialog();
           
        }
    }
}
