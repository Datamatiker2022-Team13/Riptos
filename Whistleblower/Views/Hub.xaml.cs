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
using Whistleblower.Models;
using Whistleblower.ViewModels;

namespace Whistleblower.Views
{
    /// <summary>
    /// Interaction logic for Hub.xaml
    /// </summary>
    public partial class Hub : Window
    {
        public HubViewModel HubVM { get; set; }

        public Hub () {
            InitializeComponent();

            DataContext = new HubViewModel();
        }

        private void TestTextBox_TextChanged (object sender, TextChangedEventArgs e) {
            if (InputValidator.ValidateInputIsInt(TestTextBox.Text)) {
                Uri pictureURI = new Uri(System.IO.Path.GetFullPath(@"..\..\..\") + @"\Views\Kong Kajs Karusel.png");
                TestImage.Source = new BitmapImage(pictureURI);
            }
            else {
                TestImage.Source = null;
            }
        }
    }
}
