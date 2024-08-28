using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
namespace LogicLyric.Core
{
    public class EnableConsole
    {


        

        

        
       
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        public static void AllocConsoleNow()
        {
            AllocConsole();
        }

        

        

        
        

    }
}
