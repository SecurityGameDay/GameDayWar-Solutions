public void EncryptWithHardcodedKey(string data)
{
    var secretKey = Encoding.UTF8.GetBytes("mysecretkey"); // Insecure: Hardcoded key
    Console.WriteLine("Encrypting data with hardcoded key.");

    using (var aes = Aes.Create())
    {
        aes.Key = secretKey;
        aes.GenerateIV();

        var encryptor = aes.CreateEncryptor();
        var inputData = Encoding.UTF8.GetBytes(data);
        var encryptedData = encryptor.TransformFinalBlock(inputData, 0, inputData.Length);

        Console.WriteLine("Encrypted data: " + Convert.ToBase64String(encryptedData));
    }
}

// solution

using System;
using System.Security.Cryptography;
using System.Text;

public void EncryptWithSecureKey(string data)
{
    var secretKey = GetEncryptionKey(); // Securely retrieve the key

    if (secretKey == null || secretKey.Length != 32) // Check for 256-bit AES key
    {
        throw new InvalidOperationException("Invalid encryption key. Key must be 32 bytes for AES-256.");
    }

    using (var aes = Aes.Create())
    {
        aes.Key = secretKey;
        aes.GenerateIV(); // Generate a unique IV for each encryption

        using (var encryptor = aes.CreateEncryptor())
        {
            var inputData = Encoding.UTF8.GetBytes(data);
            var encryptedData = encryptor.TransformFinalBlock(inputData, 0, inputData.Length);

            // Combine IV and encrypted data
            var result = new byte[aes.IV.Length + encryptedData.Length];
            Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
            Buffer.BlockCopy(encryptedData, 0, result, aes.IV.Length, encryptedData.Length);

            Console.WriteLine("Encrypted Data: " + Convert.ToBase64String(result));
        }
    }
}

private byte[] GetEncryptionKey()
{
    // Retrieve the key securely (e.g., from environment variables or a key vault)
    string keyBase64 = Environment.GetEnvironmentVariable("ENCRYPTION_KEY");
    return !string.IsNullOrEmpty(keyBase64) ? Convert.FromBase64String(keyBase64) : null;
}
