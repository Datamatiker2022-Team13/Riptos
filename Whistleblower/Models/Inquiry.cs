using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whistleblower.Models
{
    public class Inquiry
    {
        public Employee Sender { get; private set; }
        public Employee Receiver { get; private set; }

        public string Title { get; set; }
        public SubjectType Subject { get; set; }
        public Message Conversation { get; set; }
        public bool IsAnonymous { get; set; }

        public Inquiry(string title, SubjectType subject, Message message, bool isAnonymous,Employee sender,Employee receiver)
        {
            Sender = sender;
            Receiver = receiver;

            Title = title;
            Subject = subject;
            Conversation = message;
            IsAnonymous = isAnonymous;
        }
    }
}
