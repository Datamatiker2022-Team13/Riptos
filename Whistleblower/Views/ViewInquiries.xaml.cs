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

namespace Whistleblower.Views
{
    /// <summary>
    /// Interaction logic for ViewInquiries.xaml
    /// </summary>
    public partial class ViewInquiries : Window
    {
        public ViewInquiriesViewModel ViewInquiriesVM { get; set; }

        public ViewInquiries () {
            InitializeComponent();

            ViewInquiriesVM = new ViewInquiriesViewModel();
            DataContext = ViewInquiriesVM;
        }

        private void InquiriesListBox_SelectionChanged (object sender, SelectionChangedEventArgs e) {
            if (ViewInquiriesVM.SelectedInquiry != null) {
                DeleteInquiryButton.IsEnabled = true;
            }
            else {
                DeleteInquiryButton.IsEnabled = false;
            }
        }

        private void AddInquiryButton_Click (object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }

        private void DeleteInquiryButton_Click (object sender, RoutedEventArgs e) {
            ViewInquiriesVM.DeleteSelectedInquiry();
        }
    }
}
