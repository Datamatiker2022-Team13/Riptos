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
        public SubjectType Subjects { get; set; }
        public Message Conversation { get; set; }
        public bool IsAnonymous { get; set; }

        /// <summary>
        /// DONT USE THIS
        /// TODO : this is a temporary constructor, and should be removed later
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isAnonymous"></param>
        //public Inquiry (string title, bool isAnonymous) : this (title, null, null, isAnonymous, null, null) { }

        public Inquiry(string title, SubjectType subjects,Message message, bool isAnonymous,Employee sender,Employee receiver)
        {
            Title = title;
            Subjects = subjects;
            Conversation = message;
            IsAnonymous = isAnonymous;
            Sender = sender;
            Receiver = receiver;
        }
             
    }

}
