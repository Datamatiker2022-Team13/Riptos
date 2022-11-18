using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class Controller
    {
        public List<Employee> HREmployees { get; set; }
        public List<Employee> Employees { get; set; }

        private Program program;
        private EmployeeRepository employeeRepository;
        private InquiryRepository inquiryRepository;

        public Controller () {
            HREmployees = new List<Employee>();
            Employees = new List<Employee>();

            foreach (Employee employee in employeeRepository.GetAll()) {
                if (employee.IsHR)
                    HREmployees.Add(employee);
                else
                    Employees.Add(employee);
            }
        }

        public void SendInquiry(int receiverSelection, string title, List<SubjectType> subjects, string message, bool isAnonymous)
        {
            Message sendMessage = new Message (program.ActiveEmployee, message, DateTime.Now); //fidner ansatte ud fra brugernavn

            Inquiry inquiry = new Inquiry(title, subjects, sendMessage, isAnonymous, program.ActiveEmployee, HREmployees[receiverSelection]);
            inquiryRepository.AddInquiry(inquiry);  
        }
    }
}
