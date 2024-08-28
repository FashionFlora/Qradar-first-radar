using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric.Utils
{
    public class SimpleCipher
    {


        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string ShuffledAlphabet = "qmybdjkpzolifwhxgctvunreas"; // Our shuffled alphabet

        public static string Encrypt(int number)
        {
            string result = "";

            // Convert number to string and pad it with leading zeros to get even number of digits
            string numberAsString = number.ToString().PadLeft((number.ToString().Length + 1) / 2 * 2, '0');
            for (int i = 0; i < numberAsString.Length; i += 2)
            {
                int twoDigitNumber = int.Parse(numberAsString.Substring(i, 2));
                result += ShuffledAlphabet[twoDigitNumber % 26]; // Use modulo to prevent out of bounds
            }
            return result;
        }
    }
}
