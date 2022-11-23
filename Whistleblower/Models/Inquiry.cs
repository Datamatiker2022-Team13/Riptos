using System.Security.Cryptography.Pkcs;

namespace Whistleblower.Models
{
    public class Inquiry
    {
        private static int iDCount = 0;

        public int ID { get; private set; }

        public Employee Sender { get; private set; }
        public Employee Receiver { get; private set; }

        public string Title { get; set; }
        public SubjectType Subject { get; set; }
        public Message Conversation { get; set; }
        public bool IsAnonymous { get; set; }

        public Inquiry(Employee sender, Employee receiver, string title, SubjectType subject, Message message, bool isAnonymous)
        {
            ID = iDCount++;

            Sender = sender;
            Receiver = receiver;

            Title = title;
            Subject = subject;
            Conversation = message;
            IsAnonymous = isAnonymous;
        }

        public string GetCSVFormat () {
            return string.Format($"{Sender.ID};{Receiver.ID};{Title};{Subject};{Conversation.ID};{IsAnonymous}");
        }
    }
}
