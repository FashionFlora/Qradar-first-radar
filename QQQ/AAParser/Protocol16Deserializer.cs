using Crypt.AAParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogicLyric.AAParser
{
  

        public  class Protocol16Deserializer
        {
            private static Dictionary<byte, Protocol16Type> protocol16TypeMap;

            static Protocol16Deserializer()
            {
                protocol16TypeMap = new Dictionary<byte, Protocol16Type>
            {
                { 0, Protocol16Type.Unknown },
                { 42, Protocol16Type.Null },
                { 68, Protocol16Type.Dictionary },
                { 97, Protocol16Type.StringArray },
                { 98, Protocol16Type.Byte },
                { 100, Protocol16Type.Double },
                { 101, Protocol16Type.EventData },
                { 102, Protocol16Type.Float },
                { 105, Protocol16Type.Integer },
                { 104, Protocol16Type.Hashtable },
                { 107, Protocol16Type.Short },
                { 108, Protocol16Type.Long },
                { 110, Protocol16Type.IntegerArray },
                { 111, Protocol16Type.Boolean },
                { 112, Protocol16Type.OperationResponse },
                { 113, Protocol16Type.OperationRequest },
                { 115, Protocol16Type.String },
                { 120, Protocol16Type.ByteArray },
                { 121, Protocol16Type.Array },
                { 122, Protocol16Type.ObjectArray },
            };
            }

            public static object Deserialize(BinaryReader reader, byte typeCode)
            {
                Protocol16Type type;
                if (!protocol16TypeMap.TryGetValue(typeCode, out type))
                {
                    return null;
                    // throw new ArgumentException("Type code: " + typeCode + " not implemented.");
                }

                switch (type)
                {
                    case Protocol16Type.Unknown:
                    case Protocol16Type.Null:
                        return null;
                    case Protocol16Type.Byte:
                        return DeserializeByte(reader);
                    case Protocol16Type.Boolean:
                        return DeserializeBoolean(reader);
                    case Protocol16Type.Short:
                        return DeserializeShort(reader);
                    case Protocol16Type.Integer:
                        return DeserializeInteger(reader);
                    case Protocol16Type.IntegerArray:
                        return DeserializeIntegerArray(reader);
                    case Protocol16Type.Double:
                        return DeserializeDouble(reader);
                    case Protocol16Type.Long:
                        return DeserializeLong(reader);
                    case Protocol16Type.Float:
                        return DeserializeFloat(reader);
                    case Protocol16Type.String:
                        return DeserializeString(reader);
                    case Protocol16Type.StringArray:
                        return DeserializeStringArray(reader);
                    case Protocol16Type.ByteArray:
                        return DeserializeByteArray(reader);
                    case Protocol16Type.EventData:
                        return DeserializeEventData(reader);
                    case Protocol16Type.Dictionary:
                        return DeserializeDictionary(reader);
                    case Protocol16Type.Array:
                        return DeserializeArray(reader);
                    case Protocol16Type.OperationResponse:
                        return DeserializeOperationResponse(reader);
                    case Protocol16Type.OperationRequest:
                        return DeserializeOperationRequest(reader);
                    case Protocol16Type.Hashtable:
                        return DeserializeHashtable(reader);
                    case Protocol16Type.ObjectArray:
                        return DeserializeObjectArray(reader);
                    default:
                        throw new ArgumentException("Type code: " + typeCode + " not implemented.");
                }
            }

            private static byte DeserializeByte(BinaryReader reader)
            {
                return reader.ReadByte();
            }

            private static bool DeserializeBoolean(BinaryReader reader)
            {
              return reader.ReadBoolean();
            }

            private static ushort DeserializeShort(BinaryReader reader)
            {
            return  BinaryReaderExtensions.ReadBigEndian<ushort>(reader);
        }

            private static uint DeserializeInteger(BinaryReader reader)
            {
                return BinaryReaderExtensions.ReadBigEndian<UInt32>(reader);
        }

            private static uint[] DeserializeIntegerArray(BinaryReader reader)
            {
               uint size = DeserializeInteger(reader);
               uint[] result = new uint[size];

                for (int i = 0; i < size; i++)
                {
                    result[i] = DeserializeInteger(reader);
                }

                return result;
            }

            private static double DeserializeDouble(BinaryReader reader)
            {
                return BinaryReaderExtensions.ReadBigEndian<double>(reader);
        }

            private static UInt64 DeserializeLong(BinaryReader reader)
            {
                return BinaryReaderExtensions.ReadBigEndian<UInt64>(reader);
        }

            private static float DeserializeFloat(BinaryReader reader)
            {
                return BinaryReaderExtensions.ReadBigEndian<float>(reader);
        }

            private static string DeserializeString(BinaryReader reader)
            {
                ushort stringSize = DeserializeShort(reader);
                if (stringSize == 0)
                {
                    return string.Empty;
                }
                byte[] bytes = reader.ReadBytes(stringSize);
                return Encoding.UTF8.GetString(bytes);
            }

            private static byte[] DeserializeByteArray(BinaryReader reader)
            {
                uint arraySize = DeserializeInteger(reader);
                return reader.ReadBytes((int)arraySize);
            }

            private static object[] DeserializeArray(BinaryReader reader)
            {
                ushort size = DeserializeShort(reader);
                byte typeCode = DeserializeByte(reader);
                object[] result = new object[size];

                for (int i = 0; i < size; i++)
                {
                    result[i] = Deserialize(reader, typeCode);
                }

                return result;
            }

            private static string[] DeserializeStringArray(BinaryReader reader)
            {
                ushort size = DeserializeShort(reader);
                string[] result = new string[size];

                for (int i = 0; i < size; i++)
                {
                    result[i] = DeserializeString(reader);
                }

                return result;
            }

            private static object[] DeserializeObjectArray(BinaryReader reader)
            {
                ushort tableSize = DeserializeShort(reader);
                object[] result = new object[tableSize];

                for (int i = 0; i < tableSize; i++)
                {
                    byte typeCode = DeserializeByte(reader);
                    result[i] = Deserialize(reader, typeCode);
                }

                return result;
            }

            private static Dictionary<object, object> DeserializeHashtable(BinaryReader reader)
            {
                ushort tableSize = DeserializeShort(reader);
                return DeserializeDictionaryElements(reader, tableSize, 0, 0);
            }

            private static Dictionary<object, object> DeserializeDictionary(BinaryReader reader)
            {
                byte keyTypeCode = DeserializeByte(reader);
                byte valueTypeCode = DeserializeByte(reader);
                ushort dictionarySize = DeserializeShort(reader);
                return DeserializeDictionaryElements(reader, dictionarySize, keyTypeCode, valueTypeCode);
            }

            private static Dictionary<object, object> DeserializeDictionaryElements(BinaryReader reader,
                ushort dictionarySize, byte keyTypeCode, byte valueTypeCode)
            {
                Dictionary<object, object> output = new Dictionary<object, object>();

                for (int i = 0; i < dictionarySize; i++)
                {
                    object key = Deserialize(reader,
                        (keyTypeCode == 0 || keyTypeCode == 42) ? DeserializeByte(reader) : keyTypeCode);
                    object value = Deserialize(reader,
                        (valueTypeCode == 0 || valueTypeCode == 42) ? DeserializeByte(reader) : valueTypeCode);
                    output.Add(key, value);
                }

                return output;
            }

            public static Dictionary<byte, object> DeserializeOperationRequest(BinaryReader reader)
            {
                return DeserializeParameterTable(reader);
            }

            public static Dictionary<byte, object> DeserializeOperationResponse(BinaryReader reader)
            {
             
                ushort returnCode = DeserializeShort(reader);
                string debugMessage = (string)Deserialize(reader, DeserializeByte(reader));
                Dictionary<byte, object> parameters = DeserializeParameterTable(reader);

                return parameters;
            }

            public static Dictionary<byte, object> DeserializeEventData(BinaryReader reader)
            {
                return DeserializeParameterTable(reader);
            }

            private static Dictionary<byte, object> DeserializeParameterTable(BinaryReader reader)
            {
                ushort tableSize = BinaryReaderExtensions.ReadBigEndian<ushort>(reader);
                 Dictionary<byte, object> table = new Dictionary<byte, object>();
                for (int i = 0; i < tableSize; i++)
                {
                     byte key = reader.ReadByte();
                     byte valueTypeCode = reader.ReadByte();
                 
                    object value = Deserialize(reader, valueTypeCode);
                    table.Add(key, value);
                }

                return table;
            }
        }
    
}
