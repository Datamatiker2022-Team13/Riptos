using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Whistleblower.MVVM.Models;
using Whistleblower.MVVM.ViewModels;

namespace Whistleblower.Commands
{
    public class SendMessageCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is ViewInquiriesViewModel vm)
            {
                bool canExecute = false;

                if (!string.IsNullOrWhiteSpace(vm.MessageContent) && vm.SelectedInquiry != null)
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
            if (parameter is ViewInquiriesViewModel vm)
            {
                Message reply = MessageRepository.Instance.Create(vm.ActiveEmployeeVM.Source, vm.MessageContent, DateTime.Now);
                vm.SelectedInquiry.AddMessage(reply);

                vm.MessageContent = string.Empty;
            }
            else
            {
                throw new ArgumentException("Illegal argument!");
            }
        }
    }
}
