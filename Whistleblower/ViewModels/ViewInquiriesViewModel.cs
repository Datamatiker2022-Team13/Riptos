using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whistleblower.Models;

namespace Whistleblower.ViewModels
{
    public class ViewInquiriesViewModel : INotifyPropertyChanged
    {
        private EmployeeRepository employeeRepo = EmployeeRepository.Instance;
        private MessageRepository messageRepo = MessageRepository.Instance;
        private InquiryRepository inquiryRepo = InquiryRepository.Instance;

        public ObservableCollection<InquiryViewModel> InquiryVMs { get; set; }

        private InquiryViewModel _selectedInquiry;
        public InquiryViewModel SelectedInquiry {
            get { return _selectedInquiry; }
            set { 
                _selectedInquiry = value;
                OnPropertyChanged(nameof(SelectedInquiry));
            }
        }

        public ViewInquiriesViewModel () {
            InquiryVMs = new ObservableCollection<InquiryViewModel>();

            foreach (Inquiry inquiry in inquiryRepo.RetrieveAll()) {
                InquiryViewModel inquiryVM = new InquiryViewModel(inquiry);
                InquiryVMs.Add(inquiryVM);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged (string propertyName) {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;

            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DeleteSelectedInquiry () {
            SelectedInquiry.DeleteInquiry(inquiryRepo);
            InquiryVMs.Remove(SelectedInquiry);
        }
    }
}
