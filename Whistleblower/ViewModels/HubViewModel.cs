using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whistleblower.Models;

namespace Whistleblower.ViewModels
{
    public class HubViewModel
    {
        private EmployeeRepository employeeRepo;

        public EmployeeViewModel ActiveEmployee { get; set; }

        public HubViewModel () {
            employeeRepo = new EmployeeRepository();

            ActiveEmployee = new EmployeeViewModel(new Employee("Mikkel Pedersen", false, "mikkelmus666", "praiseTheDevil!!!"));
        }
    }
}
