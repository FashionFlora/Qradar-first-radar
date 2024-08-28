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
using LogicLyric.Utils;

namespace LogicLyric.MVM.View
{
    /// <summary>
    /// Interaction logic for DataGridBox.xaml
    /// </summary>
    public partial class DataGridBox : Window
    {
        int state = 0;
        int idx = 0;
        int idxFiltered = -1;

        public DataGridBox(int state = 0, int idx = 0, int idxFiltered = -1)
        {
            this.state = state;
            this.idx = idx;
            this.idxFiltered = idxFiltered;


            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = (SystemParameters.PrimaryScreenWidth - Width) / 2;
            Top = (SystemParameters.PrimaryScreenHeight - Height) / 2;


        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            string enteredText = textBox.Text;
            string selectedOption = comboBox.Text;

            // Do something with the entered text and selected option

            bool flag = true;

            if (enteredText.Length == 0)
            {

                flag = false;
            }


            if (flag == false)
            {

                MessageBox.Show($"Entered Text cannot be empty");
            }
            else
            {
                int count = IgnoreListItems.members.Count + 1;
                if (state == 0)
                {

                    IgnoreListItems.members.Add(new Member { Number = count.ToString(), Character = enteredText[0].ToString(), BgColor = (Brush)converter.ConvertFromString("#1098AD"), Name = enteredText, Type = selectedOption });

                    

                    Properties.Settings.Default.typeMembersSetting.Add(selectedOption);
                    Properties.Settings.Default.membersSetting.Add(enteredText);
                    Properties.Settings.Default.positionSetting.Add(count.ToString());

                    Properties.Settings.Default.Save();
                  

                }

                if (state == 1)
                {
                    Member temp = new Member { Number = (idx + 1).ToString(), Character = enteredText[0].ToString(), BgColor = (Brush)converter.ConvertFromString("#1098AD"), Name = enteredText, Type = selectedOption };
                    IgnoreListItems.members[idx] = temp;

                    if (idxFiltered != -1)
                    {
                        IgnoreListItems.filteredItems[idxFiltered] = temp;
                    }


                    Properties.Settings.Default.typeMembersSetting[idx] = selectedOption;
                    Properties.Settings.Default.membersSetting[idx] = enteredText;
                    Properties.Settings.Default.positionSetting[idx] = (idx + 1).ToString();


                    Properties.Settings.Default.Save();



                }

                Close();
            }


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the dialog without performing any action
            Close();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

    }
}
