using System.Collections.ObjectModel;
using Whistleblower.Models;

namespace Whistleblower.ViewModels
{
    public class InquiryViewModel
    {
        private Inquiry source;

        public Employee Sender { get; set; }
        public Employee Receiver { get; set; }

        public string Title { get; set; }
        public ObservableCollection<SubjectType> Subjects { get; set; }
        public ObservableCollection<Message> Conversation { get; set; }
        public bool IsAnonymous { get; set; }

        public InquiryViewModel (Inquiry source) {
            this.source = source;

            Sender = source.Sender;
            Receiver = source.Receiver;

            Title = source.Title;
            Subjects = new ObservableCollection<SubjectType>(source.Subjects);
            Conversation = new ObservableCollection<Message>(source.Conversation);
            IsAnonymous = source.IsAnonymous;
        }

        public void Delete () {
            InquiryRepository.Instance.Delete(source);
        }
    }
}
