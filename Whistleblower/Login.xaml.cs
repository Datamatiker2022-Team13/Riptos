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
using Whistleblower.Models;
using Whistleblower.ViewModels;

namespace Whistleblower
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
            

            for (int i = 0; i < EmployeeRepository.Instance.RetrieveAll().Count; i++)
            {
                if (txtUserName.Text == EmployeeRepository.Instance.RetrieveAll()[i].Username)
                {
                    if(txtPassword.Password == EmployeeRepository.Instance.RetrieveAll()[i].Password)
                    {
                        //SendInquary page = new SendInquary();
                        //NavigationService.GetNavigationService(page);//Dette lort virker ikke bare en placeholder
                        txtUserName.Text = "hejsa";
                    }
                    else
                    {
                        //print forkert kodeord 
                        lblLoginError.Content = "Din fucking spasser\n kodeordet er forket";
                        lblLoginError.Foreground = new SolidColorBrush(Color.FromRgb(100 , 0 , 0));   
                    }
                }
                else
                {
                    //Print forkert brugernavn
                    lblLoginError.Content = "Din fucking spasser\n Brugernavnet er forket";
                    lblLoginError.Foreground = new SolidColorBrush(Color.FromRgb(100, 0, 0));
                }

            }

        }


    }
}
