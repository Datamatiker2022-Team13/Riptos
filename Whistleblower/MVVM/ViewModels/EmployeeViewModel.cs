using Whistleblower.MVVM.Models;

namespace Whistleblower.MVVM.ViewModels
{
    public class EmployeeViewModel
    {
        /// <summary>
        /// The original Employee object that is represented here throught the ViewModel.
        /// </summary>
        public Employee Source { get; }

        public string Name { get; set; }
        public bool IsHR { get; set; }

        public string Username { get; set; }

        public EmployeeViewModel(Employee source)
        {
            Source = source;

            Name = source.Name;
            IsHR = source.IsHR;

            Username = source.Username;
        }

        public bool Equals(EmployeeViewModel employeeVM)
        {
            if (employeeVM.Source.ID == Source.ID)
                return true;

            return false;
        }
    }
}
