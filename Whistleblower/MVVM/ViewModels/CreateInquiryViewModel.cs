using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whistleblower.Commands;
using Whistleblower.MVVM.Models;

namespace Whistleblower.MVVM.ViewModels
{
    public class CreateInquiryViewModel
    {
        public ViewInquiriesViewModel ViewInquiriesVM { get; set; }

        public string Title { get; set; }
        public SubjectType Subject { get; set; }
        public string Content { get; set; }
        public bool IsAnonymous { get; set; }

        public List<SubjectType> Subjects { get; set; }

        public SubjectType ChosenSubject { get; set; }

        #region Commands
        public CreateInquiryCommand CreateInquiryCommand { get; } = new CreateInquiryCommand();
        #endregion

        public CreateInquiryViewModel(ViewInquiriesViewModel viewInquiriesVM)
        {
            ViewInquiriesVM = viewInquiriesVM;

            SubjectType[] subjectsArray = Enum.GetValues<SubjectType>();
            Subjects = subjectsArray.ToList();
        }
    }
}
