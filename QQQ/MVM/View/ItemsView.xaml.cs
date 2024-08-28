using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LogicLyric.MVM.View
{
    /// <summary>
    /// Interaction logic for ItemsView.xaml
    /// </summary>
    /// 

    public partial class ItemsView : Window
    {
        public bool show_items = true;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && Properties.Settings.Default.dragAndDropSetting)
            {
                DragMove();

                Properties.Settings.Default.translationItemsXSetting = (int)this.Left;
                Properties.Settings.Default.translationItemsYSetting = (int)this.Top;

                Properties.Settings.Default.Save();

            }
        }
        public ItemsView()
        {
            InitializeComponent();

            this.DataContext = this;

           
        }
        Thread t2;

        private  bool runLoop = true;


        public void initThread()
        {

            Thread t2 = new Thread(() =>
            {

                while (runLoop)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        if ( show_items)
                        {
                            canvasItems.InvalidateVisual();
                        }
 
                    });
                    Thread.Sleep(105);
                }
            });
            t2.IsBackground = true;
            t2.Start();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if(t2!=null)
            {
                runLoop = false;

                t2.Abort();
            }
        }
    }
}
