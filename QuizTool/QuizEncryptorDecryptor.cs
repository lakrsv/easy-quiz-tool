using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuizTool
{
    class QuizEncryptorDecryptor
    {
        //It is important to change this key.
        internal const string InputKey = "4K3420D2K2D3L-23EJKDWED023E329DKDWE-EKQWLDI32UEJDAKL32";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public static string EncryptRijndael(string text, string Salt)
        {
            var aesAlg = NewRijndaelManaged(Salt);

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            var msEncrypt = new MemoryStream();
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(text);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }
        public static bool IsBase64String(string base64String)
        {
            base64String = base64String.Trim();
            return (base64String.Length % 4 == 0) &&
                   Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public static string DecryptRijndael(string cipherText, string salt)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");

            if (!IsBase64String(cipherText))
            {
                MessageBox.Show("This is not a valid string to decrypt!");
                return null;
            }

            string text;

            var aesAlg = NewRijndaelManaged(salt);
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            var cipher = Convert.FromBase64String(cipherText);

            try
            {
                using (var msDecrypt = new MemoryStream(cipher))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            text = srDecrypt.ReadToEnd();
                        }
                    }
                }
                return text;
            }
            catch
            {
                MessageBox.Show("Fuck you hacka!!");
                return null;
            }
        }
        private static RijndaelManaged NewRijndaelManaged(string salt)
        {
            if (salt == null) throw new ArgumentNullException("salt");
            var saltBytes = Encoding.ASCII.GetBytes(salt);
            var key = new Rfc2898DeriveBytes(InputKey, saltBytes);

            var aesAlg = new RijndaelManaged();
            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
            aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

            return aesAlg;
        }
        public static string GetSalt()
        {
            RNGCryptoServiceProvider cryptoservice = new RNGCryptoServiceProvider();
            int salt = cryptoservice.GetHashCode();
            string tempSalt = salt.ToString();
            StringBuilder builder = new StringBuilder();

            foreach (char character in tempSalt)
            {
                builder.Append((char)RandomChar());
                builder.Append(character);
            }

            return builder.ToString();
        }
        private static char RandomChar()
        {
            Random random = new Random();
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            char ch = (char)(input[random.Next(0, input.Length)]);

            return ch;
        }
    }
}
