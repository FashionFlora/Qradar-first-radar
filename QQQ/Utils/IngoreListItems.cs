using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LogicLyric.MVM.View;

namespace LogicLyric.Utils
{
    public  class IgnoreListItems
    {

       public static ObservableCollection<Member> members = new ObservableCollection<Member>();
       public static  ObservableCollection<Member> filteredItems = new ObservableCollection<Member>();
    }
}
