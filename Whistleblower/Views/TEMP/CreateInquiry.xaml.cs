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

namespace Whistleblower.TEMP
{
    /// <summary>
    /// Interaction logic for CreateInquiry.xaml
    /// </summary>
    public partial class CreateInquiry : Window
    {
        public CreateInquiryViewModel VM { get; set; }

        public CreateInquiry(EmployeeViewModel activeEmployee)
        {
            InitializeComponent();

            VM = new CreateInquiryViewModel(activeEmployee);
            DataContext = VM;
        }

        private void SendInquiryButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
