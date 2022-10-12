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
    /// Interaction logic for AddLaborantScreen.xaml
    /// </summary>
    public partial class AddLaborantScreen : Window
    {
        public AddLaborantScreen()
        {
            InitializeComponent();
            _roleService=InstanceFactory.GetInstance<RoleService>();
           
        }
        public LaborantService _laborantService;
        private RoleService _roleService;
        private void laborantIdentityTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(laborantIdentityTbx.Text, "[a-zA-Z]") || laborantIdentityTbx.Text.Length > 11)
            {

                laborantIdentityTbx.Text = laborantIdentityTbx.Text.Remove(laborantIdentityTbx.Text.Length - 1);
            }


        }

        private void addLaborantButton_Click(object sender, RoutedEventArgs e)
        {
            if (laborantIdentityTbx.Text == "" || laborantNameTbx.Text == "" || passwordTbx.Text == "" || usernameTbx.Text == "" || laborantSurnametbx.Text == "")
            {


                MessageBox.Show("Please complete all required fields");
            }
            else if (_laborantService.GetLaborantByIdentity(laborantIdentityTbx.Text) != null)
            {
                MessageBox.Show("Laborant already has been");

            }
            else if (_laborantService.GetLaborantByUserName(usernameTbx.Text) .Name!= null)
            {
                MessageBox.Show("Username already has been");

            }
            else if (laborantIdentityTbx.Text.Length!=11)
            {
                MessageBox.Show("Identity number must be 11 digits");
            }
            else
            {
                try
                {
                    Role role = roleComboBox.SelectedItem as Role;
                    _laborantService.Add(new Entities.Laborant
                    {
                        IdentityNumber = laborantIdentityTbx.Text,
                        UserName = usernameTbx.Text,
                        Password = passwordTbx.Text,
                        Name = laborantNameTbx.Text,
                        SurName = laborantSurnametbx.Text,
                        RoleId = role.Id,
                        BirthDate=Convert.ToDateTime(birthDate.SelectedDate.Value.Date),

                    });
                    MessageBox.Show("Added");
                }
                catch(Exception ex) 
                {
                    throw new Exception(ex.Message);
                }


            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
                List<Role> roles=_roleService.GetAll();
            roleComboBox.ItemsSource = roles;
           
            roleComboBox.DisplayMemberPath = "Name";
            roleComboBox.SelectedValuePath = "Id";
            roleComboBox.SelectedItem = roles[0];

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   

        }

    }
}
