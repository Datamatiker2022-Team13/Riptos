using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Whistleblower.Models;
using Whistleblower.ViewModels;

namespace Whistleblower.Commands
{
    public class CreateInquiryCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is CreateInquiryViewModel vm)
            {
                bool canExecute = false;

                if (!string.IsNullOrWhiteSpace(vm.Title) && !string.IsNullOrWhiteSpace(vm.Content))
                    canExecute = true;

                CommandManager.InvalidateRequerySuggested();

                return canExecute;
            }
            else
            {
                Trace.WriteLine("Called before initialization, or perhaps, an illegal parameter was passed as argument?");
                return false;
            }
        }

        public void Execute(object? parameter)
        {
            if (parameter is CreateInquiryViewModel vm)
            {
                // TODO : change how the receiver is determined
                InquiryRepository.Instance.Create(
                    vm.ActiveEmployee.Source,
                    EmployeeRepository.Instance.Retrieve(1),
                    vm.Title,
                    vm.ChosenSubject,
                    MessageRepository.Instance.Create(
                        vm.ActiveEmployee.Source,
                        vm.Content,
                        DateTime.Now),
                    vm.IsAnonymous);
            }
            else
            {
                throw new ArgumentException("Illegal argument!");
            }
        }
    }
}
