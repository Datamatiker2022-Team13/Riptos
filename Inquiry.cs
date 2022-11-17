using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riptos
{
    public class Inquiry
    {
        public Employee Sender { get; private set; }
        public Employee Receiver { get; private set; }

        public string Title { get; set; }
        public List<SubjectType> Subjects { get; set; }
        public List<Message> Conversation { get; set; }
        public bool IsAnonymous { get; set; }
        public Inquiry(string title, List<SubjectType> subjects,Message message, bool isAnonymous,Employee sender,Employee receiver)
        {
            Title = title;
            Subjects = subjects;
            Conversation.Add(message);
            IsAnonymous = isAnonymous;
            Sender = sender;
            Receiver = receiver;
        }
             
    }

}
