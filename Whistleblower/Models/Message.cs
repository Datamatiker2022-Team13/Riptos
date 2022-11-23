using System;

namespace Whistleblower.Models
{
    public class Message
    {
        private static int iDCount = 0;

        public int ID { get; private set; }

        public Employee Sender { get; private set; }
        public string Content { get; private set; }
        public DateTime SendDate { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="sender">The sender of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="sendDate">The <see cref="DateTime"/> the message is sent.</param>
        public Message(Employee sender, string content, DateTime sendDate)
        {
            ID = iDCount++;

            Sender = sender;
            Content = content;
            SendDate = sendDate;
        }
    }
}
