using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Convesys.Kernel.Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
	{
		/// <summary>
		/// Convert the string to secure string
		/// </summary>
		/// <param name="input">Insecure string</param>
		/// <returns>Instance of secure string representing insecure string</returns>
		public static SecureString ToSecureString(this string input)
		{
			var secureString = new SecureString();

			if (input == null)
				return secureString;

			foreach (char c in input)
			{
				secureString.AppendChar(c);
			}

			secureString.MakeReadOnly();

			return secureString;
		}

		/// <summary>
		/// To the insecure string.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">secure string</exception>
		public static string ToInsecureString(this SecureString input)
		{
			if (input == null)
				throw new ArgumentNullException("secure string");

			var returnValue = string.Empty;

			IntPtr ptr = Marshal.SecureStringToBSTR(input);

			try
			{
				returnValue = Marshal.PtrToStringBSTR(ptr);
			}
			finally
			{
				Marshal.ZeroFreeBSTR(ptr);
			}

			return returnValue;
		}

	    public static Stream ToStream(this string s, Encoding encoding)
	    {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (encoding == null)
                throw new ArgumentNullException(nameof(encoding));

            return new MemoryStream(encoding.GetBytes(s));
        }
    }
}