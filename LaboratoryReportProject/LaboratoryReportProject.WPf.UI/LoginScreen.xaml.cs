using LaboratoryReportProject.Business.Abstracts;
using LaboratoryReportProject.Business.Auth;
using LaboratoryReportProject.Business.DependencyResolvers.Ninject;
using LaboratoryReportProject.Business.ServiceAdapters;
using LaboratoryReportProject.Business.VerifyPerson.LibraryManagamentSystem.Core.Utilities.Auth;
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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
            _laborantService=InstanceFactory.GetInstance<LaborantService>();    
            _sessionService=InstanceFactory.GetInstance<SessionService>();
            _kpsService = InstanceFactory.GetInstance<IKpsService>();



        }
        public LaborantService _laborantService;
        public SessionService _sessionService;
        public IKpsService _kpsService;

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (passwordtbx.Text == "" || userNametbx.Text == "")
            {
                MessageBox.Show("Please complete all required fields");
            }
            else {
                bool result = _laborantService.IsVerifyLaborant(userNametbx.Text, passwordtbx.Text);
                if (result)
                {
                    HomeScreen home = new HomeScreen();
                    Laborant laborant = _laborantService.GetLaborantByUserName(userNametbx.Text);
                    home._session = new Session
                    {
                        UserName = userNametbx.Text,
                        RoleId = laborant.RoleId,
                        LaborantId = laborant.Id,
                        LaborantNameAndSurname = laborant.Name + "  " + laborant.SurName,



                    };
                    home._laborantService = _laborantService;
                    home.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");

                }
            }
           
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }
    }
}
