using System;
using System.Globalization;

namespace Whistleblower.MVVM.Models
{
    public class Message
    {
        /// <summary>
        /// Internal ID counter.
        /// </summary>
        private static int iDCount = 0;

        public int ID { get; private set; }

        public Employee Sender { get; private set; }
        public string Content { get; private set; }
        public DateTime SendDateTime { get; private set; }
        public bool IsAnonymous { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="sender">The sender of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="sendDateTime">The <see cref="DateTime"/> the message is sent.</param>
        public Message(Employee sender, string content, DateTime sendDateTime, bool isAnonymous)
        {
            ID = iDCount++;

            Sender = sender;
            Content = content;
            SendDateTime = sendDateTime;
            IsAnonymous = isAnonymous;
        }
    }
}
