using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Whistleblower.Commands;
using Whistleblower.MVVM.Models;

namespace Whistleblower.MVVM.ViewModels
{
    public class ViewInquiriesViewModel : INotifyPropertyChanged
    {
        public EmployeeViewModel ActiveEmployeeVM { get; set; }

        public ObservableCollection<InquiryViewModel> InquiryVMs { get; set; }

        private InquiryViewModel _selectedInquiry;
        public InquiryViewModel SelectedInquiry
        {
            get { return _selectedInquiry; }
            set
            {
                _selectedInquiry = value;
                OnPropertyChanged(nameof(SelectedInquiry));
            }
        }

        private string _messageContent;
        public string MessageContent
        {
            get { return _messageContent; }
            set
            {
                _messageContent = value;
                OnPropertyChanged(nameof(MessageContent));
            }
        }

        #region Commands
        public ShowCreateInquiryDialogCommand ShowCreateInquiryDialogCommand { get; } = new ShowCreateInquiryDialogCommand();
        public SendMessageCommand SendMessageCommand { get; } = new SendMessageCommand();
        #endregion

        public ViewInquiriesViewModel(EmployeeViewModel activeEmployeeVM)
        {
            ActiveEmployeeVM = activeEmployeeVM;

            InquiryVMs = new ObservableCollection<InquiryViewModel>();

            foreach (Inquiry inquiry in InquiryRepository.Instance.RetrieveAll())
            {
                InquiryViewModel inquiryVM = null;

                EmployeeViewModel receiverVM = new EmployeeViewModel(inquiry.Receiver);
                EmployeeViewModel senderVM = new EmployeeViewModel(inquiry.Sender);

                if (receiverVM.Equals(ActiveEmployeeVM) || senderVM.Equals(ActiveEmployeeVM))
                    InquiryVMs.Add(new InquiryViewModel(inquiry));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;

            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DeleteSelectedInquiry()
        {
            SelectedInquiry.Delete();
            InquiryVMs.Remove(SelectedInquiry);
        }
    }
}
