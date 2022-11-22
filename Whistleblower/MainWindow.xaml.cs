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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Whistleblower.Models;

namespace Whistleblower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow () {
            InitializeComponent();

        }

        private void txt_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidateInputIsString(txt_Input.Text))
            {
                if (InputValidator.ValidateInputIsInt(txt_Input.Text))
                {
                    lbl_message.Content = "Error.. Can't accept numbers";
                }
                else
                {
                    lbl_message.Content = "No errors found... have a nice day! :D";
                }
            }
            else
            {
                lbl_message.Content = "Error... Missing input..";
            }

        }
    }
}
