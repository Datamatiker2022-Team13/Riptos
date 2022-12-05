using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Whistleblower.Models;
using Whistleblower.TEMP;
using Whistleblower.ViewModels;

namespace Whistleblower.Commands
{
    public class ShowCreateInquiryDialogCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is EmployeeMainViewModel employeeMainVM)
            {
                // creates a higher coupling between the MainViewModel and the CreateFlowerSortDialogue,
                // when MainViewModel is a parameter in the constructor of the CreateFlowerSortDialogue.
                CreateInquiry dialogue = new CreateInquiry(employeeMainVM.ActiveEmployeeVM);
                Trace.WriteLine("Opened a dialogue for creating an inquiry.");
                dialogue.ShowDialog();
            }
        }
    }
}
