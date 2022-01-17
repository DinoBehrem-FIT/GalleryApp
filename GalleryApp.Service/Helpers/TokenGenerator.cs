using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Service.Helpers
{
    public class TokenGenerator
    {
        public static string Generate(int size)
        {
            string charSet = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";

            char[] chars = charSet.ToCharArray();

            byte[] data = new byte[1];

            var crypto = new RNGCryptoServiceProvider();

            crypto.GetNonZeroBytes(data);

            data = new byte[size];

            crypto.GetNonZeroBytes(data);

            StringBuilder result = new StringBuilder(size);

            foreach (var item in data)
            {
                result.Append(chars[item % (chars.Length)]);
            }

            return result.ToString(); 
        }
    }
}
