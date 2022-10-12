using LaboratoryReportProject.Business.Abstracts;
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
    /// Interaction logic for AddPatientScreen.xaml
    /// </summary>
    public partial class AddPatientScreen : Window
    {
        public AddPatientScreen()
        {
            InitializeComponent();
        }
        public PatientService _patientService;

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        }

        private void addPatientButton_Click(object sender, RoutedEventArgs e)
        {
            if ( patientIdentityTbx.Text == "" || patientNameTbx.Text == "" || patientSurnametbx.Text == "")
            {
                MessageBox.Show("Please complete all required fields");
            }
            else if (patientIdentityTbx.Text.Length != 11)
            {
                MessageBox.Show("Identity number must be 11 digits");
            }
            else
            {
                try
                {


                    _patientService.Add(new Entities.Patient
                    {
                        Name = patientNameTbx.Text,
                        SurName = patientSurnametbx.Text,
                        IdentityNumber = patientIdentityTbx.Text,
                        BirthDate = Convert.ToDateTime(birthDate.SelectedDate.Value.Date),


                    });
                    MessageBox.Show("Added");
                }
                catch
                {
                    MessageBox.Show("Couldn't add");
                }


            }
        }

        private void patientIdentityTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(patientIdentityTbx.Text, "[a-zA-Z]") || patientIdentityTbx.Text.Length > 11)
            {

                patientIdentityTbx.Text = patientIdentityTbx.Text.Remove(patientIdentityTbx.Text.Length - 1);
            }


        }
    }
}
