using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLyric.AAParser
{
    using System;
    using System.Collections.Generic;

    public static class ObjectConverter
    {
        public static T ConvertTo<T>(object value)
        {
            if (value == null)
            {
                return default(T);
            }

            if (typeof(T) == value.GetType())
            {
                return (T)value;
            }

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public static T[] ConvertArray<T>(object[] objectsArray)
        {
            if (objectsArray == null)
            {
                return null;
            }

            List<T> resultList = new List<T>();
            foreach (object obj in objectsArray)
            {
                T convertedValue = ConvertTo<T>(obj);
                resultList.Add(convertedValue);
            }

            return resultList.ToArray();
        }













  
    }
}
