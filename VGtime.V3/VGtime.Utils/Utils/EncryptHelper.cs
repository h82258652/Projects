using System;
using System.Security.Cryptography;
using System.Text;

namespace VGtime.Utils
{
    public static class EncryptHelper
    {
        public static string AesEncryptString(string input, string key)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.ECB;

                using (var encryptor = aes.CreateEncryptor(Encoding.UTF8.GetBytes(key), aes.IV))
                {
                    var bytes = Encoding.UTF8.GetBytes(input);
                    var outputArray = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
                    return Convert.ToBase64String(outputArray);
                }
            }
        }
    }
}