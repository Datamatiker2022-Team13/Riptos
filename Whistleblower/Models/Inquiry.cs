using System.Collections.Generic;

namespace Whistleblower.Models
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
        public SubjectType Subject { get; set; }
        public List<Message> Conversation { get; set; }
        public bool IsAnonymous { get; set; }

        public Inquiry(Employee sender, Employee receiver, string title, SubjectType subject, Message message, bool isAnonymous)
        {
            ID = iDCount++;

            Sender = sender;
            Receiver = receiver;

            Title = title;
            Subject = subject;

            List<Message> conversation = new List<Message>() { message };
            Conversation = conversation;

            IsAnonymous = isAnonymous;
        }

        //public string GetCSVFormat () {
        //    return string.Format($"{Sender.ID};{Receiver.ID};{Title};{Subject};{Conversation.ID};{IsAnonymous}");
        //}
    }
}
