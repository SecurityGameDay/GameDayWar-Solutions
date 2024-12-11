public void EncryptWithHardcodedAESKey(string data)
{
    var key = Encoding.UTF8.GetBytes("1234567890123456"); // Insecure: Hardcoded key
    var iv = Encoding.UTF8.GetBytes("1234567890123456");  // Example IV (also insecure)

    using (var aes = Aes.Create())
    {
        aes.Key = key;
        aes.IV = iv;

        using (var encryptor = aes.CreateEncryptor())
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(data);
            var encryptedData = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
            Console.WriteLine($"Encrypted Data (AES): {Convert.ToBase64String(encryptedData)}");
        }
    }
}

// solution

using System;
using System.Security.Cryptography;
using System.Text;

public void EncryptWithSecureAESKey(string data)
{
    // Retrieve the encryption key securely (e.g., from a key vault or environment variable)
    var key = GetEncryptionKey(); // Replace this with a secure key retrieval mechanism

    if (key == null || key.Length != 16)
    {
        throw new InvalidOperationException("Invalid encryption key. Must be 16 bytes for AES-128.");
    }

    using (var aes = Aes.Create())
    {
        aes.Key = key;
        aes.GenerateIV(); // Securely generate a random IV for each encryption

        using (var encryptor = aes.CreateEncryptor())
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(data);
            var encryptedData = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);

            // Combine IV and encrypted data for transmission/storage
            var result = new byte[aes.IV.Length + encryptedData.Length];
            Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
            Buffer.BlockCopy(encryptedData, 0, result, aes.IV.Length, encryptedData.Length);

            Console.WriteLine($"Encrypted Data (AES): {Convert.ToBase64String(result)}");
        }
    }
}

private byte[] GetEncryptionKey()
{
    // Securely retrieve the encryption key (e.g., from environment variables or a key vault)
    string keyBase64 = Environment.GetEnvironmentVariable("ENCRYPTION_KEY"); // Example: Get key from env variable
    return !string.IsNullOrEmpty(keyBase64) ? Convert.FromBase64String(keyBase64) : null;
}
