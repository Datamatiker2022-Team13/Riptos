using System;
using Whistleblower.MVVM.Models;

namespace Whistleblower.MVVM.ViewModels
{
    public class MessageViewModel
    {
        public Message Source { get; }

        public Employee Sender { get; set; }
        public string Content { get; set; }
        public DateTime SendDateTime { get; set; }

        public MessageViewModel (Message source)
        {
            Source = source;

            Sender = source.Sender;
            Content = source.Content;
            SendDateTime = DateTime.Now;
        }

        public void Delete ()
        {
            MessageRepository.Instance.Delete(Source);
        }
    }
}
