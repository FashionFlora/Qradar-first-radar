using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypt.AAParser
{
    public static class BinaryReaderExtensions
    {
        public static T ReadBigEndian<T>(this BinaryReader reader) where T : struct
        {
            int size = GetSizeOfType<T>();
            byte[] bytes = reader.ReadBytes(size);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverterBytesToValue<T>(bytes);
        }

        private static int GetSizeOfType<T>() where T : struct
        {
            Type type = typeof(T);

            if (type.IsValueType)
            {
                return System.Runtime.InteropServices.Marshal.SizeOf(type);
            }
            else
            {
                throw new ArgumentException("Size determination is not supported for reference types.");
            }
        }


        private static T BitConverterBytesToValue<T>(byte[] bytes) where T : struct
        {
            Type type = typeof(T);
            object result;

           

            if (type == typeof(int))
            {
                result = BitConverter.ToInt32(bytes, 0);
            }
            else if (type == typeof(uint))
            {
                result = BitConverter.ToUInt32(bytes, 0);
            }
            else if (type == typeof(short))
            {
                result = BitConverter.ToInt16(bytes, 0);
            }
            else if (type == typeof(ushort))
            {
                result = BitConverter.ToUInt16(bytes, 0);
            }
            else if (type == typeof(long))
            {
                result = BitConverter.ToInt64(bytes, 0);
            }
            else if (type == typeof(ulong))
            {
                result = BitConverter.ToUInt64(bytes, 0);
            }
            else if (type == typeof(float))
            {
                result = BitConverter.ToSingle(bytes, 0);
            }
            else if (type == typeof(double))
            {
                result = BitConverter.ToDouble(bytes, 0);
            }
            else
            {
                throw new ArgumentException("Unsupported type for conversion.");
            }

            return (T)result;
        }
    }
}
