public void InsecureBase64Encryption(string data)
{
    var encryptedData = Convert.ToBase64String(Encoding.UTF8.GetBytes(data)); // Not encryption
    Console.WriteLine($"Base64 Encrypted Data: {encryptedData}");
}

// Solve the above vulnerability
public void SecureBase64Encryption(string data)
{
    var encryptedData = Convert.ToBase64String(EncryptData(Encoding.UTF8.GetBytes(data)));
    Console.WriteLine($"Base64 Encrypted Data: {encryptedData}");
}

private byte[] EncryptData(byte[] data)
{
    using (var aes = Aes.Create())
    {
        aes.GenerateIV(); // Generate a random IV for each encryption
        using (var encryptor = aes.CreateEncryptor())
        {
            var encryptedData = encryptor.TransformFinalBlock(data, 0, data.Length);

            // Combine IV and encrypted data
            var result = new byte[aes.IV.Length + encryptedData.Length];
            Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
            Buffer.BlockCopy(encryptedData, 0, result, aes.IV.Length, encryptedData.Length);

            return result;
        }
    }
}