using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric.Core
{
    class StaticLocks
    {
        public static object localLock = new object();
        public static object playersLock = new object();
        public static object mobsLock = new object();
        public static object mistsLock = new object();
        public static object harvestLock = new object();
    }
}
