using System.Collections.Generic;

namespace Whistleblower.MVVM.Models
{
    public class Inquiry
    {
        /// <summary>
        /// Internal ID counter.
        /// </summary>
        private static int iDCount = 0;

        public int ID { get; private set; }

        public Employee Sender { get; private set; }
        public Employee Receiver { get; private set; }

        public string Title { get; set; }
        public List<SubjectType> Subjects { get; set; }
        public List<Message> Conversation { get; set; }
        public bool IsAnonymous { get; set; }

        public Inquiry(Employee sender, Employee receiver, string title, List<SubjectType> subjects, List<Message> conversation, bool isAnonymous)
        {
            ID = iDCount++;

            Sender = sender;
            Receiver = receiver;

            Title = title;
            Subjects = subjects;
            Conversation = conversation;
            IsAnonymous = isAnonymous;
        }

        public Inquiry(Employee sender, Employee receiver, string title, List<SubjectType> subjects, Message message, bool isAnonymous)
            : this(sender, receiver, title, subjects, new List<Message>() { message }, isAnonymous) { }

        //public string GetCSVFormat () {
        //    return string.Format($"{Sender.ID};{Receiver.ID};{Title};{Subject};{Conversation.ID};{IsAnonymous}");
        //}
    }
}
