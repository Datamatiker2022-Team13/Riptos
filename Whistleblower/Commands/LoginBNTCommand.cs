using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Whistleblower.MVVM.Models;
using Whistleblower.MVVM.ViewModels;
using Whistleblower.MVVM.Views;

namespace Whistleblower.Commands
{
    public class TryLoginCommand : ICommand
    {

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }



        public bool CanExecute(object? parameter)
        {
            if (parameter is LoginViewModel vm)
            {
                bool lightCheck = false;

                if (!string.IsNullOrEmpty(vm.Password) && !string.IsNullOrEmpty(vm.Username))
                    lightCheck = true;
                CommandManager.InvalidateRequerySuggested();

                return lightCheck;
            }
            else
            {
                return false;

            }
        }

        public void Execute(object? parameter)
        {
            if (parameter is LoginViewModel vm)
            {
                // attempt to login

                Employee employee = EmployeeRepository.Instance.Retrieve(1);
            }
            else
            {
                throw new ArgumentException("Wrong input");
            }
        }
    }
}
