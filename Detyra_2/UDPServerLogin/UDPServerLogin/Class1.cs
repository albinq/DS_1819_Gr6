using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UDPServerLogin
{
    class Class1
    {  
            public static string Encrypt(string originalString)
            {
                if (String.IsNullOrEmpty(originalString))
                {
                    throw new ArgumentNullException
                           ("The string which needs to be encrypted can not be null.");
                }
                byte[] key = Encoding.ASCII.GetBytes("2F0DE5C5");
                byte[] iv = Encoding.ASCII.GetBytes("5C92E1AE");
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                cryptoProvider.Key = key;
                cryptoProvider.IV = iv;
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(cryptoProvider.Key, cryptoProvider.IV), CryptoStreamMode.Write);
                StreamWriter writer = new StreamWriter(cryptoStream);
                writer.Write(originalString);
                writer.Flush();
                cryptoStream.FlushFinalBlock();
                writer.Flush();
                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            public static string Decrypt(string cryptedString)
            {
                if (String.IsNullOrEmpty(cryptedString))
                {
                    throw new ArgumentNullException
                       ("The string which needs to be decrypted can not be null.");
                }
                byte[] key = Encoding.ASCII.GetBytes("2F0DE5C5");
                byte[] iv = Encoding.ASCII.GetBytes("5C92E1AE");

                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                cryptoProvider.Key = key;
                cryptoProvider.IV = iv;
                MemoryStream memoryStream = new MemoryStream
                        (Convert.FromBase64String(cryptedString));
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                    cryptoProvider.CreateDecryptor(cryptoProvider.Key, cryptoProvider.IV), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cryptoStream);
                return reader.ReadToEnd();
            }
    }
}
