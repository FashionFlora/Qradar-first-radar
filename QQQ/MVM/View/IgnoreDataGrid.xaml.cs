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
    /// Interaction logic for IgnoreDataGrid.xaml
    /// </summary>
    public partial class IgnoreDataGrid : UserControl
    {

        bool isFilteringOn = false;



        public IgnoreDataGrid()
        {

            InitializeComponent();
            var converter = new BrushConverter();
            IgnoreListItems.filteredItems.Clear();
            membersDataGrid.ItemsSource = IgnoreListItems.members;



        }


        private void Eddit_Item(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            // Get the underlying data object bound to the row
            Member dataObject = (Member)clickedButton.DataContext;


            // Get the index of the data object within the ItemsSource collection
            int rowIndexFilter = membersDataGrid.Items.IndexOf(dataObject);
            int rowIndex = int.Parse(dataObject.Number) - 1;

            DataGridBox dialog = null;
            if (isFilteringOn)
            {
                dialog = new DataGridBox(1, rowIndex, rowIndexFilter);
            }
            else
            {
                dialog = new DataGridBox(1, rowIndex, -1);
            }




        //    dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;  // Set window startup location to center on owner window
            dialog.ShowDialog();

            // Use the rowIndex as needed
            //   MessageBox.Show("Clicked button in row index: " + rowIndex);
        }


        private void Delete_Item(object sender, RoutedEventArgs e)
        {


            Button clickedButton = (Button)sender;
            var converter = new BrushConverter();
            // Get the underlying data object bound to the row
            Member dataObject = (Member)clickedButton.DataContext;

            // Get the index of the data object within the ItemsSource collection
            int rowIndexFilter = membersDataGrid.Items.IndexOf(dataObject);
            int rowIndex = int.Parse(dataObject.Number) - 1;


            // Use the rowIndex as needed

            IgnoreListItems.members.RemoveAt(rowIndex);

            Properties.Settings.Default.typeMembersSetting.RemoveAt(rowIndex);
            Properties.Settings.Default.membersSetting.RemoveAt(rowIndex);
            Properties.Settings.Default.positionSetting.RemoveAt(rowIndex);


            Properties.Settings.Default.Save();
            //     MessageBox.Show("Clicked button in row index: " + dataObject.Number);


            for (int i = rowIndex; i < IgnoreListItems.members.Count; i++)
            {

                Member pp = (Member)IgnoreListItems.members[i];
                Member temp = new Member { Number = (int.Parse(pp.Number) - 1).ToString(), Character = pp.Name[0].ToString(), BgColor = (Brush)converter.ConvertFromString("#1098AD"), Name = pp.Name, Type = pp.Type };


                IgnoreListItems.members[i] = temp;





            }

            if (isFilteringOn)
            {

                IgnoreListItems.filteredItems.RemoveAt(rowIndexFilter);

                for (int i = rowIndexFilter; i < IgnoreListItems.filteredItems.Count; i++)
                {

                    Member pp = (Member)IgnoreListItems.filteredItems[i];
                    Member temp = new Member { Number = (int.Parse(pp.Number) - 1).ToString(), Character = pp.Name[0].ToString(), BgColor = (Brush)converter.ConvertFromString("#1098AD"), Name = pp.Name, Type = pp.Type };


                    IgnoreListItems.filteredItems[i] = temp;
                }
            }





        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = textBoxFilter.Text.ToLower();


            IgnoreListItems.filteredItems.Clear();
            if (searchText.Length == 0)
            {

                membersDataGrid.ItemsSource = IgnoreListItems.members;
                isFilteringOn = false;
                return;


            }
            else
            {
                isFilteringOn = true;

            }


            //    IgnoreListItems.filteredItemss = new ObservableCollection<Member>(Items.Where(item => item.Name.ToLower().Contains(searchText)));


            foreach (Member p in IgnoreListItems.members)
            {

                if (p.Name.ToLower().Contains(searchText))
                {
                    IgnoreListItems.filteredItems.Add(p);
                }
            }

            // Replace "Name" with the actual property of your Item class that you want to search against.

            membersDataGrid.ItemsSource = IgnoreListItems.filteredItems;

        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataGridBox dialog = new DataGridBox();


            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;  // Set window startup location to center on owner window
            dialog.ShowDialog();


            // Retrieve data or result from the dialog if needed
            // For example, you can access a public property on the DialogWindow to retrieve data
            // var data = dialog.SomeProperty;
        }
    }

    public class Member
    {
        public string Character { get; set; }
        public Brush BgColor { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public string Type { get; set; }

    }


}
