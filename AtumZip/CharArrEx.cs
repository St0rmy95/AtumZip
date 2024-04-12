using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ace_Globals.Extensions
{
    /// <summary>
    /// Helper class for conversions between character arrays and string
    /// </summary>
    public static class CharArrEx
    {
        /// <summary>
        /// Gets a C# string without trailing zeros of a native string buffer
        /// </summary>
        /// <param name="nativeString">Native string buffer</param>
        /// <returns>Managed string without trailing zeros</returns>
        public static string ToManagedString(this char[] nativeString)
        {
            return new string(nativeString).TrimEnd('\0');
        }

        /// <summary>
        /// Creates a zero padded character array buffer from a managed string
        /// </summary>
        /// <param name="managedStr">The managed string</param>
        /// <param name="bufferLength">Length of the native Buffer</param>
        /// <returns>The native buffer</returns>
        public static char[] ToNativeString(this string managedStr, int bufferLength)
        {
            // Validate buffer long enough
            if (bufferLength <= 1)
                throw new ArgumentException("The buffer length cannot be smaller than 2 for an unmanaged string!", "bufferLength");

            // Char-by-Char copy
            char[] tmp = new char[bufferLength];
            if (!String.IsNullOrEmpty(managedStr))
            {
                for (int i = 0; i < managedStr.Length && i < bufferLength - 1; i++)
                    tmp[i] = managedStr[i];
            }
            return tmp;
        }
    }
}
