using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace InsecureCryptographyLibrary
{
    public class InsecureCryptography
    {
        // 1. MD5 Hashing (Weak Cryptography)
        public static string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        // 2. Storing sensitive data in plain text
        public static void StoreData(string data)
        {
            File.WriteAllText("sensitiveData.txt", data); // Storing data insecurely
        }

        // 3. Weak Token Generation (Insecure Randomness)
        public static string GenerateToken()
        {
            byte[] tokenBytes = new byte[16];
            RandomNumberGenerator.Create().GetBytes(tokenBytes);
            return Convert.ToBase64String(tokenBytes); // Weak token generation
        }

        // 4. Using weak ciphers (DES)
        public static string EncryptDataWithDES(string data)
        {
            using (DES des = DES.Create())
            {
                des.Key = Encoding.UTF8.GetBytes("12345678"); // Weak key
                des.IV = Encoding.UTF8.GetBytes("12345678");
                using (var encryptor = des.CreateEncryptor(des.Key, des.IV))
                {
                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    return Convert.ToBase64String(encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length));
                }
            }
        }

        // 5. Storing session tokens insecurely
        public static void StoreSessionToken(string token)
        {
            File.AppendAllText("sessionTokens.txt", token); // Insecure storage of session tokens
        }
    }
}
