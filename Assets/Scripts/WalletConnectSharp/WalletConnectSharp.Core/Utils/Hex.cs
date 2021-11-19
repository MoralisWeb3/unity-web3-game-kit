using System;
using System.Text.RegularExpressions;

namespace WalletConnectSharp.Core.Utils
{
    public static class Hex
    {
        public static string ToHex(this byte[] data, bool includeDashes = false)
        {
            var b = BitConverter.ToString(data);
            return includeDashes ? b : b.Replace("-", "");
        }

        public static bool IsHex(this string str, int? length = null)
        {
            string pattern = @"/^0x[0-9A-Fa-f]*$/";

            if (!Regex.Match(str, pattern).Success)
            {
                return false;
            }

            if (length != null && str.Length != 2 + 2 * length)
            {
                return false;
            }

            return true;
        }
        
        public static byte[] FromHex(this string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}