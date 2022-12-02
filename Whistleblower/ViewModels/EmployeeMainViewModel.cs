using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whistleblower.Commands;
using Whistleblower.Models;

namespace Whistleblower.ViewModels
{
    public class EmployeeMainViewModel
    {
        public EmployeeViewModel ActiveEmployeeVM { get; set; }

        public ObservableCollection<InquiryViewModel> InquiryVMs { get; set; }

        #region Commands
        public ShowCreateInquiryDialogCommand ShowCreateInquiryDialogCommand { get; } = new ShowCreateInquiryDialogCommand();
        #endregion

        public EmployeeMainViewModel()
        {
            ActiveEmployeeVM = new EmployeeViewModel(EmployeeRepository.Instance.Retrieve(0));

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
    }
}
