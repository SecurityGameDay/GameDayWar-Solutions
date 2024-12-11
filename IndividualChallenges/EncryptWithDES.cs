public void EncryptWithDES(byte[] data, byte[] key, byte[] iv)
{
    var des = DES.Create(); // Insecure encryption algorithm
    des.Key = key;          // Must be 8 bytes
    des.IV = iv;            // Must be 8 bytes

    using (var encryptor = des.CreateEncryptor())
    {
        var encryptedData = encryptor.TransformFinalBlock(data, 0, data.Length);
        Console.WriteLine($"Encrypted Data (DES): {Convert.ToBase64String(encryptedData)}");
    }
}

// solution 

using System;
using System.Security.Cryptography;

public void EncryptWithAES(byte[] data, byte[] key, byte[] iv)
{
    if (key.Length != 16) // AES 128-bit key (16 bytes)
    {
        Console.WriteLine("Invalid key size. Key must be 16 bytes for AES 128.");
        return;
    }
    
    if (iv.Length != 16) // AES IV size (16 bytes)
    {
        Console.WriteLine("Invalid IV size. IV must be 16 bytes for AES.");
        return;
    }

    using (var aes = Aes.Create()) // AES encryption
    {
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC; // CBC mode for AES
        aes.Padding = PaddingMode.PKCS7;

        using (var encryptor = aes.CreateEncryptor())
        {
            var encryptedData = encryptor.TransformFinalBlock(data, 0, data.Length);
            Console.WriteLine($"Encrypted Data (AES): {Convert.ToBase64String(encryptedData)}");
        }
    }
}
