using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
namespace LogicLyric.MVM.Model
{
    /// <summary>
    /// Interaction logic for UserModel.xaml
    /// </summary>
    public partial class UserModel 
    {
   
        public String Id { get; set; }
        public String Username { get; set; }

        public String Password { get; set; }

        public String Name { get; set; }
        public string LastName { get; set; }
        public String Email { get; set; }
    }
}
