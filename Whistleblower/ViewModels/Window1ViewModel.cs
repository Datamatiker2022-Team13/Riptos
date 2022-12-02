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
    public class Window1ViewModel: INotifyPropertyChanged

    {
        public EmployeeViewModel ActiveEmployee { get; set; }

        public InquiryViewModel SelectedInquiry { get; set; }
        public ObservableCollection<InquiryViewModel> Inquiries { get; set; }

        public Window1ViewModel ()
        {
            // TODO: UDKOMMENTER DET HER EFTER TESTING
            ActiveEmployee = new EmployeeViewModel(EmployeeRepository.Instance.Retrieve(0));

            Inquiries = new ObservableCollection<InquiryViewModel> ();

            foreach (Inquiry inquiry in InquiryRepository.Instance.RetrieveAll())
            {
                EmployeeViewModel receiverVM = new EmployeeViewModel(inquiry.Receiver);
                EmployeeViewModel senderVM = new EmployeeViewModel(inquiry.Sender);

                if (receiverVM.Equals(ActiveEmployee) || senderVM.Equals(ActiveEmployee))
                {
                    Inquiries.Add(new InquiryViewModel(inquiry));
                }
            }
        }

        private string createNewMessage = "Create new message";
        public string CreateNewMessage
        {
            get { return createNewMessage; }
            set { createNewMessage = value; OnPropertyChanged(nameof(CreateNewMessage)); }
        }

        private string writeMessageHere = "Bully";

        public string WriteMessageHere
        {
            get { return writeMessageHere; }
            set { writeMessageHere = value; OnPropertyChanged(nameof(WriteMessageHere)); }
        }

        private DateTime dateAndTime = DateTime.Now;

        public DateTime DateAndTime
        {
            get { return dateAndTime; }
            set { dateAndTime = value; OnPropertyChanged(nameof(DateAndTime)); }
        }
        private string titleForUser = "Welcome";

        public string TitleForUser
        {
            get { return titleForUser; }
            set { titleForUser = value; OnPropertyChanged(nameof(TitleForUser)); }
        }
        private string myList;
        
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string MyList
        {
            get { return myList; }
            set { myList = value; OnPropertyChanged(nameof(MyList)); }
        }





    }
}
