using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class Controller
    {
        private Program program;
        private EmployeeRepository employeeRepository;
        private InquiryRepository inquiryRepository;

        public void SendInquiry(int receiverSelection, string title, List<SubjectType> subjects, string message, bool isAnonymous)
        {
            Message sendMessage = new Message (program.ActiveEmployee, message, DateTime.Now);//fidner ansatte ud fra brugernavn
            Inquiry inquiry = new Inquiry(title, subjects, sendMessage, isAnonymous,program.ActiveEmployee,employeeRepository.GetEmployee(receiverUsername));
            inquiryRepository.AddInquiry(inquiry);  
        }
    }
}
