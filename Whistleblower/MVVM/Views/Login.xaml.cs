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
        public LoginViewModel VM;

        public Login()
        {
            InitializeComponent();

            VM = new LoginViewModel();
            DataContext = VM;
        }

        private void bntLogin_Click(object sender, RoutedEventArgs e)
        {
            Employee activeEmployee = null;

            foreach (Employee employee in EmployeeRepository.Instance.RetrieveAll())
            {
                if (employee.Username.Equals(VM.Username) && employee.Password.Equals(VM.Password))
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
