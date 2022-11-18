using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class Message
    {
        public Employee Sender { get; private set; }
        public string Content { get; private set; }
        public DateTime SendDate { get; private set; }

        public Message(Employee employee, string content, DateTime sendDate)
        {
            Sender = employee;
            Content = content;
            SendDate = sendDate;
        }
    }
}
