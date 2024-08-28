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

namespace LogicLyric.MVM.View
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Dialog dialog = new Dialog();
            dialog.Width = 300;
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                string inputValue = dialog.InputValue;
                // User clicked "Yes", inputValue contains the user's input
            }
            else
            {
                // User clicked "No" or closed the dialog
            }
        }
    }
}
