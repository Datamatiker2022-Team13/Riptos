using Whistleblower.Models;

namespace Whistleblower.ViewModels
{
    public class InquiryViewModel
    {
        private Inquiry source;

        public Employee Sender { get; set; }
        public Employee Receiver { get; set; }

        public string Title { get; set; }
        public SubjectType Subject { get; set; }
        public Message Conversation { get; set; }
        public bool IsAnonymous { get; set; }

        public InquiryViewModel (Inquiry source) {
            this.source = source;

            Sender = source.Sender;
            Receiver = source.Receiver;

            Title = source.Title;
            Subject = source.Subject;
            Conversation = source.Conversation;
            IsAnonymous = source.IsAnonymous;
        }

        public void DeleteInquiry (InquiryRepository inquiryRepo) {
            inquiryRepo.Delete(source);
        }
    }
}
