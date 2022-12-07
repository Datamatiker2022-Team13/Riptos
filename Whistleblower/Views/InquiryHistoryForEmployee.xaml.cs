using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Whistleblower.ViewModels;

namespace Whistleblower
{
    /// <summary>
    /// Interaction logic for InquiryHistoryForEmployee.xaml
    /// </summary>
    public partial class InquiryHistoryForEmployee : Window
    {
        public InquiryHistoryForEmployee()
        {
            InitializeComponent();
            DataContext = new ViewInquiriesViewModel();
        }
    }
}
