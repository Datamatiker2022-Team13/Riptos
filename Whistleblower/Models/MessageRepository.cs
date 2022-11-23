using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whistleblower.Models
{
    public class MessageRepository
    {
        // TODO : IMPLEMENT THIS BOIIIS
        private EmployeeRepository employeeRepo;

        private List<Message> messages;

        public MessageRepository (EmployeeRepository employeeRepo) {
           this.employeeRepo = employeeRepo;

            messages = new List<Message>();
        }

        public Message Retrieve (int id) {

            return new Message(employeeRepo.GetEmployee(0), "æhæhæh", DateTime.Now);
            // DAMMIT throw new NotImplementedException();
        }
    }
}
