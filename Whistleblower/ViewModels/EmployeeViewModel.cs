using Whistleblower.Models;

namespace Whistleblower.ViewModels
{
    public class EmployeeViewModel
    {
        /// <summary>
        /// The original Employee object that is represented here throught the ViewModel.
        /// </summary>
        private Employee source;

        public string Name { get; set; }
        public bool IsHR { get; set; }

        public string Username { get; set; }

        public EmployeeViewModel (Employee source) {
            this.source = source;

            Name = source.Name;
            IsHR = source.IsHR;

            Username = source.Username;
        }
    }
}
