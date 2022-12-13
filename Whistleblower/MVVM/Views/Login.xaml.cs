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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Whistleblower.MVVM.Views;
using Whistleblower.MVVM.ViewModels;
using Whistleblower.MVVM.Models;
using System.Diagnostics;

namespace Whistleblower.MVVM.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            DataContext = new LoginViewModel();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                Employee activeEmployee = null;

                foreach (Employee employee in EmployeeRepository.Instance.RetrieveAll())
                {
                    if (employee.Username.Equals(vm.Username) && employee.Password.Equals(vm.Password))
                    {
                        activeEmployee = employee;
                    }
                }

                if (activeEmployee == null)
                    Trace.WriteLine("Login attempt unsuccesfull 😢");
                else
                {
                    ViewInquiries page = new ViewInquiries(new EmployeeViewModel(activeEmployee));
                    page.Show();
                    Close();
                }
            }
        }
    }
}
